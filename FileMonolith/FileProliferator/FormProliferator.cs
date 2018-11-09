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
using static System.Environment;

namespace FileProliferator
{
    public partial class FormProliferator : Form
    {
        public FormProliferator()
        {
            InitializeComponent();
            buttonRefFile.Enabled = false;
            checkRefFile.Checked = false;
        }

        private string[] selectedFilePaths { get; set; }

        private string referenceFileName { get; set; }

        private string outputDirectory { get; set; }

        private void buttonFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            inputFileDialog.Filter = "All files (*.*)|*.*";
            inputFileDialog.Multiselect = true;

            DialogResult selectionResult = inputFileDialog.ShowDialog();
            if (selectionResult != DialogResult.OK) return;
            
            selectedFilePaths = inputFileDialog.FileNames;

            string filesText = "";
            foreach (string filePath in selectedFilePaths)
            {
                filesText += string.Format("\"{0}\" ", Path.GetFileName(filePath));
            }
            textFiles.Text = filesText;
        }
        
        private void checkRefFile_CheckedChanged(object sender, EventArgs e)
        {
            buttonRefFile.Enabled = checkRefFile.Checked;
        }

        private void buttonRefFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            inputFileDialog.Filter = "All files (*.*)|*.*";

            DialogResult selectionResult = inputFileDialog.ShowDialog();
            if (selectionResult != DialogResult.OK) return;

            referenceFileName = Path.GetFileName(inputFileDialog.FileName);
            textRefFile.Text = string.Format("\"{0}\" ", referenceFileName);
        }

        private void buttonOutDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog outputDialogue = new FolderBrowserDialog();
            outputDialogue.ShowNewFolderButton = true;
            outputDialogue.Description = "Choose a folder where the directory structure will be created. Making a new folder is highly recommended.";
            outputDialogue.RootFolder = SpecialFolder.MyComputer;
            if (selectedFilePaths != null)
                outputDialogue.SelectedPath = Path.GetDirectoryName(selectedFilePaths[0]);

            DialogResult selectionResult = outputDialogue.ShowDialog();
            if (selectionResult != DialogResult.OK) return;

            outputDirectory = outputDialogue.SelectedPath;
            textOutDir.Text = outputDirectory;
        }

        private void buttonProliferate_Click(object sender, EventArgs e)
        {
            ProliferateManager Proliferator = new ProliferateManager();

            if (selectedFilePaths != null)
                if (outputDirectory != null)
                    if (!checkRefFile.Checked)
                        Proliferator.DoProliferate(selectedFilePaths, outputDirectory);
                    else if (checkRefFile.Checked && referenceFileName != null)
                        Proliferator.DoProliferateWithReference(selectedFilePaths, outputDirectory, referenceFileName);
                    else
                        MessageBox.Show("Please select a Reference File.");
                else
                    MessageBox.Show("Please select an output folder.");
            else
                MessageBox.Show("Please choose file(s) to build directories for.");
        }
    }
}
