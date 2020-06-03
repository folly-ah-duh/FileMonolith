using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextureAggregator
{
    class AggregateManager
    {
        public event EventHandler<FeedbackEventArgs> SendFeedback;


        protected virtual void OnSendFeedback(object feedback)
        {
            SendFeedback?.Invoke(this, new FeedbackEventArgs() { Feedback = feedback });
        }

        public void DoAggregate(string[] textures, string archivePath, string outputDir)
        {
            OnSendFeedback("Reading TppMasterFileList...");
            string[] TppFileList = File.ReadAllLines("TppMasterFileList.txt");
            IEnumerable<string> ftexsEntries = TppFileList.Where(entry => entry.EndsWith(".ftexs") && !entry.EndsWith(".1.ftexs"));

            OnSendFeedback("Scanning for .pftxs Textures...");
            List<string> pullFiles = new List<string>();
            foreach (string ftexsEntry in ftexsEntries)
            {
                if (textures.Any(texture => ftexsEntry.StartsWith(texture)))
                {
                    pullFiles.Add(ftexsEntry);
                }
            }

            foreach (string textureFile in pullFiles)
            {
                PullFile(Path.Combine(archivePath, textureFile), outputDir);
            }
        }


        internal void PullFile(string srcPath, string outputDir)
        {
            string filename = Path.GetFileName(srcPath); // pulls to root of output directory. TODO add an option to keep directory structure
            string dstPath = Path.Combine(outputDir, filename);
            if (!File.Exists(dstPath)) // all original .2+.ftexs live outside packs, so the monolith can be condensed or uncondensed 
            {
                if (File.Exists(srcPath))
                {
                    OnSendFeedback("Pulling...\n" + filename);
                    File.Copy(srcPath, dstPath);
                }
            }
        }
        
    }
}
