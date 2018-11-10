using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTextureConverter
{
    class ConvertManager
    {
        public void DoMassConversion(string inputDirectory, string outputDirectory, bool subFolders)
        {
            string[] ftexFiles = GetFtexFiles(inputDirectory, subFolders);
            ConvertTextures(ftexFiles, inputDirectory, outputDirectory);
        }

        private string[] GetFtexFiles(string searchDirectory, bool searchSubFolders)
        {
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
                ddsOutputDir = Path.GetDirectoryName(ddsOutputDir);
                ddsOutputDir = Path.Combine(outputRootDir, ddsOutputDir);

                if (!Directory.Exists(ddsOutputDir))
                    Directory.CreateDirectory(ddsOutputDir);

                string[] ftexToolArgs = { ftexFilePath, ddsOutputDir };
                FtexTool.Program.Main(ftexToolArgs);

            }
        }
    }
}
