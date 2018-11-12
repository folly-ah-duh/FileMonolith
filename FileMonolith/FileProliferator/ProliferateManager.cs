﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProliferator
{
    public class ProliferateManager
    {
        public static string[] TppFileList = File.ReadAllLines("TppMasterFileList.txt");

        public event EventHandler<FeedbackEventArgs> SendFeedback;

        protected virtual void OnSendFeedback(string feedback)
        {
            SendFeedback?.Invoke(this, new FeedbackEventArgs() { Feedback = feedback });
        }

        public void DoProliferate(string[] filesToProlif, string outputPath)
        {
            foreach (string fileToProlif in filesToProlif)
            {
                string fileName = Path.GetFileName(fileToProlif);
                List<string> foundDirectories = SearchDirectoriesEndsWith(fileName);

                if (foundDirectories.Count() == 0)
                    OnSendFeedback(string.Format("No results for {0}", fileName));
                else
                {
                    OnSendFeedback(fileName);
                    CopyFilesToDirectories(outputPath, foundDirectories, fileToProlif);
                }
            }
        }

        public void DoProliferateFromReference(string[] filesToProlif, string outputPath, string referenceFile)
        {
            List<string> foundDirectories = SearchDirectoriesEndsWith(referenceFile);

            if (foundDirectories.Count() == 0)
                OnSendFeedback(string.Format("No results for {0}", referenceFile));
            else
            {
                OnSendFeedback(referenceFile);
                CopyFilesToDirectories(outputPath, foundDirectories, filesToProlif);
            }
        }

        private List<string> SearchDirectoriesEndsWith(string fileName)
        {
            List<string> foundDirectories = new List<string>();

            foreach (string TppFile in TppFileList)
                if (TppFile.EndsWith(fileName))
                    foundDirectories.Add(Path.GetDirectoryName(TppFile));
            return foundDirectories;
        }

        private void CopyFilesToDirectories(string outputPath, List<string> tppPaths, params string[] filepaths)
        {
            foreach (string tppPath in tppPaths)
            {
                string fullPath = Path.Combine(outputPath, tppPath);
                if (!Directory.Exists(fullPath))
                    Directory.CreateDirectory(fullPath);
                foreach (string filePath in filepaths)
                {
                    string newFilePath = Path.Combine(fullPath, Path.GetFileName(filePath));
                    File.Copy(filePath, newFilePath, true);
                }
            }
        }
    }
}
