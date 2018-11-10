using FolderSelect;
using System;
using System.IO;
using System.Windows.Forms;
using static System.Environment;

namespace ArchiveUnpacker
{
    public partial class FormUnpacker : Form
    {
        public FormUnpacker()
        {
            InitializeComponent();
        }

        private string[] archivePaths { get; set; }

        private string outputDir { get; set; }

        private bool condensed { get; set; }

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
            FolderSelectDialog selectionDialog = new FolderSelectDialog();
            selectionDialog.Title = "Choose a folder where the .dat files will unpack into. Making a new folder is highly recommended.";
            if (selectionDialog.ShowDialog() != true) return;
            string directoryPath = selectionDialog.FileName;

            outputDir = directoryPath;
            textOutDir.Text = directoryPath;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            UnpackManager archiveUnpacker = new UnpackManager();
            FormProcessesingUnpack processWindow = new FormProcessesingUnpack();
            archiveUnpacker.SendFeedback += processWindow.OnSendFeedback;

            if (archivePaths != null)
                if (outputDir != null)
                {
                    ProcessingWindow.Show(processWindow, new Action((MethodInvoker)delegate { archiveUnpacker.DoUnpack(archivePaths, outputDir, checkCondenseDir.Checked); }));
                    MessageBox.Show("Done");
                }
                else
                    MessageBox.Show("Please select an output folder.");
            else
                MessageBox.Show("Please choose which archives to unpack.");
        }
    }
}
