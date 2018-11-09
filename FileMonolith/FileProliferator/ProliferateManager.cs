using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProliferator
{
    class ProliferateManager // todo: events and processing window,  + texture packing options
    {
        public void DoProliferate(string[] filesToProlif, string outputPath)
        {
            foreach(string fileToProlif in filesToProlif)
            {
                string fileName = Path.GetFileName(fileToProlif);
                List<string> foundDirectories = SearchDirectories(fileName);
                if (foundDirectories.Count() == 0)
                    Console.WriteLine("No results for {0}", fileName);
                else
                    CopyFilesToDirectories(foundDirectories, outputPath, filesToProlif);
            }
        }

        public void DoProliferateWithReference(string[] filesToProlif, string outputPath, string referenceFile)
        {
            List<string> foundDirectories = SearchDirectories(referenceFile);
            if (foundDirectories.Count() == 0)
                Console.WriteLine("No results found for {0}", referenceFile);
            else
                CopyFilesToDirectories(foundDirectories, outputPath, filesToProlif);
        }

        public List<string> SearchDirectories(string fileName)
        {
            string[] TppFileList = File.ReadAllLines("TppFileList.txt");
            List<string> foundDirectories = new List<string>();
            foreach (string TppFile in TppFileList)
                if (TppFile.EndsWith(fileName))
                    foundDirectories.Add(Path.GetDirectoryName(TppFile));
            return foundDirectories;
        }

        public void CopyFilesToDirectories(string filePath, List<string> tppPaths, string outputPath)
        {
            foreach(string tppPath in tppPaths)
            {
                string fullPath = Path.Combine(outputPath, tppPath);
                string newFilePath = Path.Combine(fullPath, Path.GetFileName(filePath));
                if (!Directory.Exists(fullPath))
                    Directory.CreateDirectory(fullPath);
                File.Copy(filePath, newFilePath, true);
                Console.WriteLine("Copied to {0}", newFilePath);
            }
        }

        public void CopyFilesToDirectories(List<string> tppPaths, string outputPath, params string[] filepaths)
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

        public void PackTextures() { }// Should I add an option to pull textures from vanilla pftxs and pack them with modified textures? 
        // makebite/snakebite doesn't autofill pftxs files like it does with fpk/fpkd
        // consider effect textures, the user would need to manually pack every pftxs
        // honestly this is more of a problem with makebite/snakebite, but unless it gets an update I'll have to accomodate
    }
}
