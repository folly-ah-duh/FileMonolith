using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FtexTool;
using System.IO;

namespace FileProliferator
{
    class TextureManager
    {

        public event EventHandler<FeedbackEventArgs> SendFeedback;

        public static string[] TppFileList = File.ReadAllLines("TppMasterFileList.txt");

        private int conversionFailedCount = 0;

        private int textureNotFoundCount = 0;

        protected virtual void OnSendFeedback(string feedback)
        {
            SendFeedback?.Invoke(this, new FeedbackEventArgs() { Feedback = feedback });
        }

        public string[] convertDdsToFtex(string[] filePaths)
        {
            List<string> newFilePaths = new List<string>();
            foreach (string filePath in filePaths)
            {
                if (filePath.EndsWith(".dds", StringComparison.OrdinalIgnoreCase))
                {
                    string fileNameNoExtension = Path.GetFileNameWithoutExtension(filePath);
                    string fileDir = Path.GetDirectoryName(filePath);
                    try
                    {
                        string[] ftexArgs = { filePath };
                        FtexTool.Program.Main(ftexArgs);

                        OnSendFeedback("Converting: " + Path.GetFileName(filePath));
                        newFilePaths.AddRange(Directory.GetFiles(fileDir, String.Format("{0}*.ftex?", fileNameNoExtension), SearchOption.TopDirectoryOnly));
                    }
                    catch (FtexTool.Exceptions.FtexToolException)
                    {
                        conversionFailedCount++;
                    }

                }
                else
                {
                    newFilePaths.Add(filePath);
                }
            }
            return newFilePaths.ToArray();
        }

        public void PackPftxsFolders(string directoryPath)
        {
            string[] allPftxsDirPaths = Directory.GetDirectories(directoryPath, "*_pftxs", SearchOption.AllDirectories);
            foreach(string pftxsDirPath in allPftxsDirPaths)
            {
                string pftxsFileName = Path.GetFileName(pftxsDirPath).Replace("_pftxs", ".pftxs");
                string pftxsFilePath = Path.Combine(Path.GetDirectoryName(pftxsDirPath), pftxsFileName);

                OnSendFeedback("Packing: " + pftxsFileName);
                try
                {
                    AutoPftxsTool.ArchiveHandler.WritePftxsArchive(pftxsFilePath, pftxsDirPath);

                    if (File.Exists(pftxsFilePath))
                    {
                        DeleteDirectory(pftxsDirPath);
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("IO EXCPEITON");
                }
            }
        }

        internal void PullVanillaTextures(string outputDirectory, string vanillaTexturesPath, params string[] inputFilePaths)
        {
            List<string> pftxsPaths = new List<string>();
            foreach (string inputFilePath in inputFilePaths)
            {
                string fileName = Path.GetFileName(inputFilePath);
                foreach (string ProliferatePath in SearchDirectoriesEndsWith(fileName))
                {
                    if (ProliferatePath.Contains("_pftxs"))
                    {
                        int pftxsPathLength = ProliferatePath.IndexOf("_pftxs") + 6; //big big abrain
                        string pftxsPath = ProliferatePath.Substring(0, pftxsPathLength);
                        if (!pftxsPaths.Contains(pftxsPath))
                        {
                            pftxsPaths.Add(pftxsPath);
                        }
                    }
                }
            }
            foreach (string pftxsPath in pftxsPaths)
            {
                OnSendFeedback("Pulling Textures: " + Path.GetFileName(pftxsPath));
                List<string> TppListedTexturePaths = SearchPathsContaining(pftxsPath); //oof but necessary?
                foreach (string TppListedTexturePath in TppListedTexturePaths)
                {
                    string textureFilename = Path.GetFileName(TppListedTexturePath);
                    string textureTppListedDirPath = Path.GetDirectoryName(TppListedTexturePath);

                    string foundTexturePath = findTexturePath(vanillaTexturesPath, pftxsPath, TppListedTexturePath);
                    if (foundTexturePath != null)
                    {
                        string fullOutputPath = Path.Combine(outputDirectory, textureTppListedDirPath);

                        if (!Directory.Exists(fullOutputPath))
                        {
                            Directory.CreateDirectory(fullOutputPath);
                        }

                        string newFilePath = Path.Combine(outputDirectory, TppListedTexturePath);
                        if(!File.Exists(newFilePath))
                        {
                            File.Copy(foundTexturePath, newFilePath);
                        }
                    }
                    else
                    {
                        textureNotFoundCount++;
                    }
                }
            }
        }
        private string findTexturePath(string vanillaTexturesPath, string pftxsPath, string TppListedTexturePath)
        {
            string expectedTexturePath = Path.Combine(vanillaTexturesPath, TppListedTexturePath); //Expected path if textures were unpacked with Archive Unpacker
            if (File.Exists(expectedTexturePath))
            {
                return expectedTexturePath;
            }

            string condensedTexturePath = (TppListedTexturePath.Remove(0, pftxsPath.Length + 1)); //Expected path if textures were unpacked with Archive Unpacker's Condensed Directory Structure
            condensedTexturePath = Path.Combine(vanillaTexturesPath, condensedTexturePath);
            if (File.Exists(condensedTexturePath))
            {
                return condensedTexturePath;
            }

            string textureFileName = Path.GetFileName(TppListedTexturePath);
            var directoryInfo = new DirectoryInfo(vanillaTexturesPath).EnumerateFiles(textureFileName, SearchOption.AllDirectories).FirstOrDefault(); //Desperate search
            if (directoryInfo != null)
            {
                return directoryInfo.FullName;
            }
            else
            {
                return null;
            }
        }

        public static void DeleteDirectory(string dir)
        {
            foreach (string directory in Directory.GetDirectories(dir))
            {
               DeleteDirectory(directory);
            }

            try
            {
                Directory.Delete(dir, true);
            }
            catch (IOException)
            {
                Directory.Delete(dir, true);
            }
            catch (System.UnauthorizedAccessException)
            {
                Directory.Delete(dir, true);
            }
        }

        private List<string> SearchDirectoriesEndsWith(string fileName)
        {
            List<string> foundDirectories = new List<string>();

            foreach (string TppFile in TppFileList)
            {
                if (TppFile.Contains(fileName))
                {
                    foundDirectories.Add(Path.GetDirectoryName(TppFile));
                }
            }
            return foundDirectories;
        }

        private List<string> SearchPathsContaining(string pathSnippet)
        {
            List<string> foundFiles = new List<string>();

            foreach (string TppFile in TppFileList)
            {
                if (TppFile.Contains(pathSnippet))
                {
                    foundFiles.Add(TppFile);
                }
            }
            return foundFiles;
        }

        public int getConversionFailedCount()
        {
            return conversionFailedCount;
        }

        public int getTextureNotFoundCount()
        {
            return textureNotFoundCount;
        }
    }
}
