using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FolderSelect;

namespace MassTextureConverter
{
    public partial class FormMassTexConverter : Form
    {
        private string inputDirectory { get; set; }

        private string outputDirectory { get; set; }

        public FormMassTexConverter()
        {
            InitializeComponent();
            checkConvertSubfolders.Checked = true;
        }

        private void buttonInDir_Click(object sender, EventArgs e)
        {
            FolderSelectDialog selectionDialog = new FolderSelectDialog();
            selectionDialog.Title = "Select a folder containing .ftex and .ftexs files.";
            if (selectionDialog.ShowDialog() != true) return;
            string directoryPath = selectionDialog.FileName;

            textInDir.Text = directoryPath;
            inputDirectory = directoryPath;

        }

        private void buttonOutDir_Click(object sender, EventArgs e)
        {
            FolderSelectDialog selectionDialog = new FolderSelectDialog();
            selectionDialog.Title = "Choose an output folder. Making a new folder is highly recommended.";
            if (selectionDialog.ShowDialog() != true) return;
            string directoryPath = selectionDialog.FileName;

            textOutDir.Text = directoryPath;
            outputDirectory = directoryPath;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ConvertManager converter = new ConvertManager();

            if (inputDirectory != null)
                if (outputDirectory != null)
                    converter.DoMassConversion(inputDirectory, outputDirectory, checkConvertSubfolders.Checked);
                else
                    MessageBox.Show("Please select an output folder.");
            else
                MessageBox.Show("Please select an input folder.");
        }
    }
}
