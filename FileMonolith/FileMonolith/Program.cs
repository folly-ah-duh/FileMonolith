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

        public static void DoUnpack(string[] archiveFilePaths, string outputDir, bool isCondensed)
        {
            ReadDictionaries();
            UnpackQarArchives(archiveFilePaths, outputDir);
            UnpackChildArchives(outputDir, isCondensed);
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
        
        public static void UnpackChildArchives(string rootDir, bool moveToRoot)
        {
            string[] archiveFiles = Directory.GetFiles(rootDir, "*", SearchOption.AllDirectories);
            List<string> ChildPaths;
            using (StreamWriter sw = File.CreateText(Path.Combine(rootDir, "TppFileList.txt")))
            {
                if (moveToRoot)
                    foreach (string filePath in archiveFiles)
                    {
                        string fileDir = Path.GetDirectoryName(filePath);
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                        string extension = Path.GetExtension(filePath).Replace(".", "");

                        string unpackPath = string.Format("{0}\\{1}_{2}", fileDir, fileNameWithoutExtension, extension);
                        string unpackPathWithoutRootDir = unpackPath.Remove(0, rootDir.Length);

                        switch (extension)
                        {
                            case "fpk":
                            case "fpkd":
                                ChildPaths = ReadArchive<FpkFile>(filePath, rootDir);
                                foreach (string childPath in ChildPaths)
                                    sw.WriteLine(Path.Combine(unpackPathWithoutRootDir, childPath));
                                break;
                            case "pftxs":
                                ChildPaths = ReadArchive<PftxsFile>(filePath, rootDir);
                                foreach (string childPath in ChildPaths)
                                    sw.WriteLine(Path.Combine(unpackPathWithoutRootDir, childPath));
                                break;
                            case "sbp":
                                ChildPaths = ReadArchive<SbpFile>(filePath, rootDir);
                                foreach (string childPath in ChildPaths)
                                    sw.WriteLine(Path.Combine(unpackPathWithoutRootDir, childPath));
                                break;
                        }
                    }
                else
                    foreach (string filePath in archiveFiles)
                    {
                        string fileDir = Path.GetDirectoryName(filePath);
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                        string extension = Path.GetExtension(filePath).Replace(".", "");

                        string unpackPath = string.Format("{0}\\{1}_{2}", fileDir, fileNameWithoutExtension, extension);
                        string unpackPathWithoutRootDir = unpackPath.Remove(0, rootDir.Length);

                        switch (extension)
                        {
                            case "fpk":
                            case "fpkd":
                                ChildPaths = ReadArchive<FpkFile>(filePath, unpackPath);
                                foreach (string childPath in ChildPaths)
                                    sw.WriteLine(Path.Combine(unpackPathWithoutRootDir, childPath));
                                break;
                            case "pftxs":
                                ChildPaths = ReadArchive<PftxsFile>(filePath, unpackPath);
                                foreach (string childPath in ChildPaths)
                                    sw.WriteLine(Path.Combine(unpackPathWithoutRootDir, childPath));
                                break;
                            case "sbp":
                                ChildPaths = ReadArchive<SbpFile>(filePath, unpackPath);
                                foreach (string childPath in ChildPaths)
                                    sw.WriteLine(Path.Combine(unpackPathWithoutRootDir, childPath));
                                break;
                        }
                    }
            }

        }

        public static List<string> ReadArchive<T>(string filePath, string outputDir) where T : ArchiveFile, new()
        {

            IDirectory iDir = new FileSystemDirectory(outputDir);
            List<string> fileNames = new List<string>();

            using (FileStream input = new FileStream(filePath, FileMode.Open))
            {
                T file = new T();
                file.Name = Path.GetFileName(filePath);
                file.Read(input);
                foreach (var exportedFile in file.ExportFiles(input))
                {
                    string filename = exportedFile.FileName;

                    fileNames.Add(filename);
                    iDir.WriteFile(filename, exportedFile.DataStream);
                }

            }
            return fileNames;
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
