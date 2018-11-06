using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMonolith
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private string[] archivePaths { get; set; }

        private string outputDir { get; set; }

        private void buttonArchives_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputDialog = new OpenFileDialog();
            inputDialog.Filter = "Archive Files|*.dat";
            inputDialog.Multiselect = true;

            DialogResult selectionResult = inputDialog.ShowDialog();
            if (selectionResult != DialogResult.OK) return;
            archivePaths = inputDialog.FileNames;
            Array.Sort(archivePaths); Array.Reverse(archivePaths);
            string archiveText = "";
            foreach (string archivePath in archivePaths)
            {
                string archiveName = Path.GetFileName(archivePath);
                string archiveDir = Path.GetFileName(Path.GetDirectoryName(archivePath));
                archiveText += string.Format("\"{0}/{1}\" ", archiveDir, archiveName);
            }
            textArchives.Text = archiveText;
        }

        private void buttonOutDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog outputDialogue = new FolderBrowserDialog();
            outputDialogue.ShowNewFolderButton = true;
            DialogResult selectionResult = outputDialogue.ShowDialog();
            if (selectionResult != DialogResult.OK) return;
            outputDir = outputDialogue.SelectedPath;
            textOutDir.Text = outputDir;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Program.DoUnpack(archivePaths, outputDir);
        }
    }
}
