using System;
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
            ProliferateExtraFtexs(filesToProlif, outputPath);
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

        private void ProliferateExtraFtexs(string[] filesToProlif, string outputPath)  // Edge case: If the user has more ftexs files than the vanilla texture, this needs to proliferate the extras (but not into pftxs folders).
        {
            foreach (string fileToProlif in filesToProlif)
            {
                if (fileToProlif.EndsWith(".ftex"))
                {
                    List<string> ftexsFilePaths = new List<string>();
                    string textureName = Path.GetFileNameWithoutExtension(fileToProlif);
                    List<string> TppPathsFtexNoPftxs = SearchDirectoriesNoPftxsEndsWith(Path.GetFileName(fileToProlif));

                    for (int i = 1; i <= 6; i++) // .1.ftexs through .6.ftexs
                    {
                        string ftexsFileName = string.Format("{0}.{1}.ftexs", textureName, i);
                        string ftexsFilePath = Path.Combine(fileToProlif, ftexsFileName);
                        if (filesToProlif.Contains(ftexsFilePath))
                        {
                            Console.WriteLine("an ftexs file for the ftex is contained in filestoprolif");
                            if (!ftexsFilePaths.Contains(ftexsFileName))
                            {
                                ftexsFilePaths.Add(ftexsFilePath);
                            }
                        }
                    }
                    foreach(string ftexsFilePath in ftexsFilePaths)
                    {
                        if (SearchDirectoriesEndsWith(ftexsFilePath).Count == 0) // an ftexs file that the user is trying to proliferate does not exist in the vanilla files (their texture has more ftexs than the vanilla texture)
                        {
                            CopyFilesToDirectories(outputPath, TppPathsFtexNoPftxs, ftexsFilePath);
                        }
                    }
                }
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

        private List<string> SearchDirectoriesNoPftxsEndsWith(string fileName)
        {
            List<string> foundDirectories = new List<string>();

            foreach (string TppFile in TppFileList)
                if (TppFile.EndsWith(fileName))
                    if (!TppFile.Contains("_pftxs"))
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
