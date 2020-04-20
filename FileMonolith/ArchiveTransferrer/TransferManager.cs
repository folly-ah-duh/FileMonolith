using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GzsTool.Core.Gzs;
using GzsTool.Core.Qar;
using GzsTool.Core.Common.Interfaces;
using GzsTool.Core.Common;
using GzsTool.Core.Utility;
using System.Xml.Serialization;

namespace ArchiveTransferrer
{
    class TransferManager
    {
        public event EventHandler<FeedbackEventArgs> SendFeedback;

        protected virtual void OnSendFeedback(object feedback)
        {
            SendFeedback?.Invoke(this, new FeedbackEventArgs() { Feedback = feedback });
        }

        public void Transfer(string g0sSrcPath, string mgoTexPath, string masterDir)
        {
            OnSendFeedback("Reading dictionaries...");
            // READ DICTIONARIES
            ReadDictionaries();


            OnSendFeedback("Creating temp directory...");
            // CREATE WORK DIRECTORY
            string workDir = "temp";
            string g0sWorkDir = Path.Combine(workDir, "texture6_gzs0_dat");
            Directory.CreateDirectory(g0sWorkDir);


            OnSendFeedback("Copying Ground Zeroes Archive...");
            // COPY G0S TO WORK DIRECTORY
            string g0sCpyPath = Path.Combine(workDir, Path.GetFileName(g0sSrcPath));
            File.Copy(g0sSrcPath, g0sCpyPath, true);


            OnSendFeedback("Extracting data_01.g0s...");
            // OPEN G0S
            IDirectory outputDirectory = new FileSystemDirectory(g0sWorkDir);
            using (FileStream input = new FileStream(g0sCpyPath, FileMode.Open))
            {
                GzsFile file = new GzsFile();
                file.Name = Path.GetFileNameWithoutExtension(g0sCpyPath);
                file.Read(input);
                foreach (var exportedFile in file.ExportFiles(input))
                {
                    OnSendFeedback(exportedFile.FileName);
                    outputDirectory.WriteFile(exportedFile.FileName, exportedFile.DataStream);
                }
            }


            OnSendFeedback("Copying texture6_gzs0.dat.xml...");
            // COPY REFERENCE XML TO WORK DIRECTORY
            string datXmlDstPath = Path.Combine(workDir, "texture6_gzs0.dat.xml");
            File.Copy("texture6_gzs0.dat.xml", datXmlDstPath, true);


            OnSendFeedback("Formatting texture6_gzs0.dat...");
            // WRITE DAT
            WriteArchive(datXmlDstPath);


            OnSendFeedback("Moving texture6_gzs0.dat...");
            // COPY DAT TO MASTER/
            string GZDatSrc = Path.Combine(workDir, "texture6_gzs0.dat");
            string GZDatDst = Path.Combine(masterDir, "texture6_gzs0.dat");
            File.Copy(GZDatSrc, GZDatDst);


            OnSendFeedback("Copying MGO Archive...");
            // COPY MGO DAT TO MASTER/
            string MGODatDst = Path.Combine(masterDir, "texture5_mgo0.dat");
            File.Copy(mgoTexPath, GZDatDst);
        }

        private static void ReadDictionaries()
        {
            string executingAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            /*
            const string qarDictionaryName = "qar_dictionary.txt";
            try
            {
                Hashing.ReadDictionary(Path.Combine(executingAssemblyLocation, qarDictionaryName));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading {0}: {1}", qarDictionaryName, e.Message);
            }
            */
            const string gzsDictionaryName = "gzs_dictionary.txt";
            try
            {
                Hashing.ReadDictionaryLegacy(Path.Combine(executingAssemblyLocation, gzsDictionaryName));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading {0}: {1}", gzsDictionaryName, e.Message);
            }
            /*
            const string fpkDictionaryName = "fpk_dictionary.txt";
            try
            {
                Hashing.ReadMd5Dictionary(Path.Combine(executingAssemblyLocation, fpkDictionaryName));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading {0}: {1}", fpkDictionaryName, e.Message);
            }
            */
        }

        private static readonly XmlSerializer ArchiveSerializer = new XmlSerializer(
            typeof(ArchiveFile),
            new[] { typeof(QarFile) });

        private static void WriteArchive(string path)
        {
            var directory = Path.GetDirectoryName(path);
            using (FileStream xmlInput = new FileStream(path, FileMode.Open))
            {
                ArchiveFile file = ArchiveSerializer.Deserialize(xmlInput) as ArchiveFile;
                if (file == null)
                {
                    Console.WriteLine("Error: Unknown archive type");
                    return;
                }

                WriteArchive(file, directory);
            }
        }

        private static void WriteArchive(ArchiveFile archiveFile, string workingDirectory)
        {
            string outputPath = Path.Combine(workingDirectory, archiveFile.Name);
            string fileSystemInputDirectory = string.Format("{0}\\{1}_{2}", workingDirectory,
                Path.GetFileNameWithoutExtension(archiveFile.Name), Path.GetExtension(archiveFile.Name).Replace(".", ""));
            IDirectory inputDirectory = new FileSystemDirectory(fileSystemInputDirectory);
            using (FileStream output = new FileStream(outputPath, FileMode.Create))
            {
                archiveFile.Write(output, inputDirectory);
            }
        }
    }
}
