using GzsTool.Core.Common;
using GzsTool.Core.Common.Interfaces;
using GzsTool.Core.Fpk;
using GzsTool.Core.Pftxs;
using GzsTool.Core.Qar;
using GzsTool.Core.Sbp;
using GzsTool.Core.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace TextureAggregator
{

    public class UnpackManager
    {

        public event EventHandler<FeedbackEventArgs> SendFeedback;

        protected virtual void OnSendFeedback(object feedback)
        {
            SendFeedback?.Invoke(this, new FeedbackEventArgs() { Feedback = feedback });
        }

        public string[] DoUnpack(string pftxsPath, string outputDir)
        {
            OnSendFeedback("Reading Dictionaries...");
            ReadDictionaries();

            OnSendFeedback(string.Format("Unpacking {0}...", Path.GetFileName(pftxsPath)));
            var unpackedFiles = ReadArchive<PftxsFile>(pftxsPath, outputDir);
            return unpackedFiles.Where(file => file.EndsWith(".ftex")).Select(file => file.Substring(0, file.Length - 5)).ToArray(); // full path but without extension
        }

        private void ReadDictionaries()
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
        }

        public List<string> ReadArchive<T>(string filePath, string outputDir) where T : ArchiveFile, new()
        {

            IDirectory iDir = new FileSystemDirectory(outputDir);
            List<string> fileNames = new List<string>();

            using (FileStream input = new FileStream(filePath, FileMode.Open))
            {
                T file = new T();
                file.Read(input);
                foreach (var exportedFile in file.ExportFiles(input))
                {
                    fileNames.Add(exportedFile.FileName);

                    string nameOnly = Path.GetFileName(exportedFile.FileName);
                    string exportedFileFullName = Path.Combine(outputDir, nameOnly);
                    if (!File.Exists(exportedFileFullName))
                    {
                        iDir.WriteFile(nameOnly, exportedFile.DataStream);
                    }

                    /* TODO option to export to directory structure
                    string exportedFileFullName = Path.Combine(outputDir, exportedFile.FileName);
                    if (!File.Exists(exportedFileFullName))
                    {
                        iDir.WriteFile(exportedFile.FileName, exportedFile.DataStream);
                    }
                    */
                }
            }
            return fileNames;
        }
        
    }
}
