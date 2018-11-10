using FolderSelect;
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
            FolderSelectDialog selectionDialog = new FolderSelectDialog();
            selectionDialog.Title = "Choose a folder where the .dat files will unpack into. Making a new folder is highly recommended.";
            if (selectionDialog.ShowDialog() != true) return;
            string directoryPath = selectionDialog.FileName;

            outputDirectory = directoryPath;
            textOutDir.Text = directoryPath;
        }

        private void buttonProliferate_Click(object sender, EventArgs e)
        {
            ProliferateManager Proliferator = new ProliferateManager();
            FormProcessingProliferation processWindow = new FormProcessingProliferation();
            Proliferator.SendFeedback += processWindow.OnSendFeedback;

            if (selectedFilePaths != null)
                if (outputDirectory != null)
                    if (!checkRefFile.Checked)
                    {
                        ProcessingWindow.Show(processWindow, new Action((MethodInvoker)delegate { Proliferator.DoProliferate(selectedFilePaths, outputDirectory); }));
                        MessageBox.Show("Done");
                    }
                    else if (checkRefFile.Checked && referenceFileName != null)
                    {
                        ProcessingWindow.Show(processWindow, new Action((MethodInvoker)delegate { Proliferator.DoProliferateFromReference(selectedFilePaths, outputDirectory, referenceFileName); }));
                        MessageBox.Show("Done");
                    }
                    else
                        MessageBox.Show("Please select a Reference File.");
                else
                    MessageBox.Show("Please select an output folder.");
            else
                MessageBox.Show("Please choose file(s) to build directories for.");
        }
    }
}
