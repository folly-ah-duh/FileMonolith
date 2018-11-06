using GzsTool.Core.Common;
using GzsTool.Core.Common.Interfaces;
using GzsTool.Core.Fpk;
using GzsTool.Core.Pftxs;
using GzsTool.Core.Qar;
using GzsTool.Core.Sbp;
using GzsTool.Core.Utility;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace FileMonolith
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        public static void DoUnpack(string[] archiveFilePaths, string outputDir)
        {
            ReadDictionaries();
            UnpackQarArchives(archiveFilePaths, outputDir);
            UnpackChildArchives(outputDir);
        }

        public static void UnpackQarArchives(string[] qarFilePaths, string outputDir)
        {
            foreach (string filePath in qarFilePaths)
            {
                try
                {
                    ReadArchive<QarFile>(filePath, outputDir);
                }
                catch(ArgumentOutOfRangeException)
                {
                    string filename = Path.GetFileName(filePath);
                    MessageBox.Show(filename + " could not be unpacked.");
                }
            }
        }

        public static void UnpackChildArchives(string searchDirectory)
        {
            string[] archiveFiles = Directory.GetFiles(searchDirectory, "*", SearchOption.AllDirectories);
            foreach (string filePath in archiveFiles)
            {
                string fileDir = Path.GetDirectoryName(filePath);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                string extension = Path.GetExtension(filePath).Replace(".", "");

                string outputDirectoryPath = string.Format("{0}\\{1}_{2}", fileDir, fileNameWithoutExtension, extension);

                switch (extension)
                {
                    case "fpk":
                    case "fpkd":
                        ReadArchive<FpkFile>(filePath, outputDirectoryPath);
                        break;
                    case "pftxs":
                        ReadArchive<PftxsFile>(filePath, outputDirectoryPath);
                        break;
                    case "sbp":
                        ReadArchive<SbpFile>(filePath, outputDirectoryPath);
                        break;
                }
            }

        }

        public static void ReadArchive<T>(string filePath, string outputDir) where T : ArchiveFile, new()
        {
            Console.WriteLine(filePath);

            IDirectory iDir = new FileSystemDirectory(outputDir);

            using (FileStream input = new FileStream(filePath, FileMode.Open))
            {
                T file = new T();
                file.Name = Path.GetFileName(filePath);
                file.Read(input);
                foreach (var exportedFile in file.ExportFiles(input))
                {
                    Console.WriteLine(exportedFile.FileName);
                    iDir.WriteFile(exportedFile.FileName, exportedFile.DataStream);
                }

            }
        }

        private static void ReadDictionaries()
        {
            string executingAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            const string qarDictionaryName = "qar_dictionary.txt";
            try
            {
                Hashing.ReadDictionary(Path.Combine(executingAssemblyLocation, qarDictionaryName));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading {0}: {1}", qarDictionaryName, e.Message);
            }

            const string fpkDictionaryName = "fpk_dictionary.txt";
            try
            {
                Hashing.ReadMd5Dictionary(Path.Combine(executingAssemblyLocation, fpkDictionaryName));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading {0}: {1}", fpkDictionaryName, e.Message);
            }
        }
    }
}
