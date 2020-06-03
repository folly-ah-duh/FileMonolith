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

        public string[] DoUnpack(string pftxsPath, string outputDir, bool condense)
        {
            OnSendFeedback("Reading Dictionaries...");
            ReadDictionaries();

            OnSendFeedback(string.Format("Unpacking {0}...", Path.GetFileName(pftxsPath)));
            var unpackedFiles = ReadArchive<PftxsFile>(pftxsPath, outputDir, condense);
            return unpackedFiles.Where(file => file.EndsWith(".ftex")).ToArray();
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

        public List<string> ReadArchive<T>(string filePath, string outputDir, bool condense) where T : ArchiveFile, new()
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
                    
                    string name = condense ? Path.GetFileName(exportedFile.FileName) : exportedFile.FileName;

                    string exportedFileFullName = Path.Combine(outputDir, name);
                    if (!File.Exists(exportedFileFullName))
                    {
                        iDir.WriteFile(name, exportedFile.DataStream);
                    }
                }
            }
            return fileNames;
        }
        
    }
}
