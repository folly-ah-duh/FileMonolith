using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTextureConverter
{
    public class FeedbackEventArgs : EventArgs { public string Feedback { get; set; } }

    public class ConvertManager
    {
        public event EventHandler<FeedbackEventArgs> SendFeedback;

        private int conversionFailedCount = 0;

        protected virtual void OnSendFeedback(string feedback)
        {
            SendFeedback?.Invoke(this, new FeedbackEventArgs() { Feedback = feedback });
        }

        public void DoMassConversion(string inputDirectory, string outputDirectory, bool subFolders)
        {
            string[] ftexFiles = GetFtexFiles(inputDirectory, subFolders);
            ConvertTextures(ftexFiles, inputDirectory, outputDirectory);
        }

        private string[] GetFtexFiles(string searchDirectory, bool searchSubFolders)
        {
            OnSendFeedback("Finding .ftex files...");

            string[] ftexFiles;

            if (searchSubFolders)
                ftexFiles = Directory.GetFiles(searchDirectory, "*.ftex", SearchOption.AllDirectories);
            else
                ftexFiles = Directory.GetFiles(searchDirectory, "*.ftex", SearchOption.TopDirectoryOnly);

            return ftexFiles;
        }

        private void ConvertTextures(string[] filePaths, string inputRootDir, string outputRootDir)
        {
            int numRemoveRootDir = inputRootDir.Length + 1;
            foreach (string ftexFilePath in filePaths)
            {
                string ddsOutputDir = ftexFilePath.Remove(0, numRemoveRootDir);

                OnSendFeedback(ddsOutputDir);

                ddsOutputDir = Path.GetDirectoryName(ddsOutputDir);
                ddsOutputDir = Path.Combine(outputRootDir, ddsOutputDir);

                if (!Directory.Exists(ddsOutputDir))
                    Directory.CreateDirectory(ddsOutputDir);

                try
                {
                    FtexTool.Program.UnpackFtexFile(ftexFilePath, ddsOutputDir);
                } 
                catch (FtexTool.Exceptions.MissingFtexsFileException)
                {
                    conversionFailedCount++;
                }

            }
        }

        public int GetFailureCount()
        {
            return conversionFailedCount;
        }
    }
}
