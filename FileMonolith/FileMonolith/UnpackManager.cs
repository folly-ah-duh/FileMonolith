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
using System.Reflection;
using System.Windows.Forms;

namespace FileMonolith
{
    public class FeedbackEventArgs : EventArgs { public string Feedback { get; set; } }

    public class UnpackManager // todo texture conversion options and tppfilelist -> masterlist
    {
        public event EventHandler<FeedbackEventArgs> SendFeedback;

        protected virtual void OnSendFeedback(string _archiveName)
        {
            SendFeedback?.Invoke(this, new FeedbackEventArgs() { Feedback = _archiveName });
        }

        public void DoUnpack(string[] archiveFilePaths, string outputDir, bool isCondensed)
        {
            ReadDictionaries();
            UnpackQarArchives(archiveFilePaths, outputDir);
            UnpackChildArchives(outputDir, isCondensed);
            // add option to convert ftex to dds?
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

        public void UnpackQarArchives(string[] qarFilePaths, string outputDir)
        {
            foreach (string filePath in qarFilePaths)
            {
                try
                {
                    OnSendFeedback(Path.GetFileName(filePath));
                    ReadArchive<QarFile>(filePath, outputDir);
                }
                catch (ArgumentOutOfRangeException)
                {
                    string filename = Path.GetFileName(filePath);
                    MessageBox.Show(filename + " could not be unpacked.");
                }
            }
        }

        public void UnpackChildArchives(string rootDir, bool moveToRoot) // note: archives preexisting in the rootDir will be read. Unintended functionality, not sure whether to change it.
        {
            File.Delete(Path.Combine(rootDir, "TppFileList.txt")); // TppFileList.txt should live with the .exe's and a TppMasterFileList.txt, so that the user can swap out the master file list

            string[] archiveFiles = Directory.GetFiles(rootDir, "*", SearchOption.AllDirectories);
            List<string> ChildPaths;

            using (StreamWriter TppFileList = File.CreateText(Path.Combine(rootDir, "TppFileList.txt")))
            {
                if (moveToRoot)
                    foreach (string filePath in archiveFiles)
                    {
                        TppFileList.WriteLine(filePath.Remove(0, rootDir.Length + 1));  // +1 to get rid of the '/' at the beginning

                        string extension = Path.GetExtension(filePath).Replace(".", "");

                        string unpackPath = string.Format("{0}\\{1}_{2}", Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath), extension);
                        string unpackPathWithoutRootDir = unpackPath.Remove(0, rootDir.Length + 1);

                        switch (extension)
                        {
                            case "fpk":
                            case "fpkd":
                                ChildPaths = ReadArchive<FpkFile>(filePath, rootDir);
                                foreach (string childPath in ChildPaths)
                                    TppFileList.WriteLine(Path.Combine(unpackPathWithoutRootDir, childPath));
                                OnSendFeedback(unpackPathWithoutRootDir);
                                break;
                            case "pftxs":
                                ChildPaths = ReadArchive<PftxsFile>(filePath, rootDir);
                                foreach (string childPath in ChildPaths)
                                    TppFileList.WriteLine(Path.Combine(unpackPathWithoutRootDir, childPath));
                                OnSendFeedback(unpackPathWithoutRootDir);
                                break;
                            case "sbp":
                                ChildPaths = ReadArchive<SbpFile>(filePath, rootDir);
                                foreach (string childPath in ChildPaths)
                                    TppFileList.WriteLine(Path.Combine(unpackPathWithoutRootDir, childPath));
                                OnSendFeedback(unpackPathWithoutRootDir);
                                break;
                        }
                    }
                else
                    foreach (string filePath in archiveFiles)
                    {
                        TppFileList.WriteLine(filePath.Remove(0, rootDir.Length + 1));

                        string extension = Path.GetExtension(filePath).Replace(".", "");

                        string unpackPath = string.Format("{0}\\{1}_{2}", Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath), extension);
                        string unpackPathWithoutRootDir = unpackPath.Remove(0, rootDir.Length + 1);

                        switch (extension)
                        {
                            case "fpk":
                            case "fpkd":
                                ChildPaths = ReadArchive<FpkFile>(filePath, unpackPath);
                                foreach (string childPath in ChildPaths)
                                    TppFileList.WriteLine(Path.Combine(unpackPathWithoutRootDir, childPath));
                                OnSendFeedback(unpackPathWithoutRootDir);
                                break;
                            case "pftxs":
                                ChildPaths = ReadArchive<PftxsFile>(filePath, unpackPath);
                                foreach (string childPath in ChildPaths)
                                    TppFileList.WriteLine(Path.Combine(unpackPathWithoutRootDir, childPath));
                                OnSendFeedback(unpackPathWithoutRootDir);
                                break;
                            case "sbp":
                                ChildPaths = ReadArchive<SbpFile>(filePath, unpackPath);
                                foreach (string childPath in ChildPaths)
                                    TppFileList.WriteLine(Path.Combine(unpackPathWithoutRootDir, childPath));
                                OnSendFeedback(unpackPathWithoutRootDir);
                                break;
                        }
                    }
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
                    iDir.WriteFile(exportedFile.FileName, exportedFile.DataStream);
                }

            }
            return fileNames;
        }

    }
}
