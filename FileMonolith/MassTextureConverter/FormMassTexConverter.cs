using System;
using System.Windows.Forms;
using FolderSelect;
using ProcessWindow;

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
            if (textInDir.Text != null)
                selectionDialog.InitialDirectory = textInDir.Text;
            if (selectionDialog.ShowDialog() != true) return;
            string directoryPath = selectionDialog.FileName;

            textInDir.Text = directoryPath;
            inputDirectory = directoryPath;

        }

        private void buttonOutDir_Click(object sender, EventArgs e)
        {
            FolderSelectDialog selectionDialog = new FolderSelectDialog();
            selectionDialog.Title = "Choose an output folder. Making a new folder is highly recommended.";
            if (textOutDir.Text != null)
                selectionDialog.InitialDirectory = textOutDir.Text;
            if (selectionDialog.ShowDialog() != true) return;
            string directoryPath = selectionDialog.FileName;

            textOutDir.Text = directoryPath;
            outputDirectory = directoryPath;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ConvertManager converter = new ConvertManager();
            FormProcessingConversion processWindow = new FormProcessingConversion();
            converter.SendFeedback += processWindow.OnSendFeedback;

            if (inputDirectory != null)
                if (outputDirectory != null)
                {
                    ProcessingWindow.Show(processWindow, new Action((MethodInvoker)delegate { converter.DoMassConversion(inputDirectory, outputDirectory, checkConvertSubfolders.Checked); }));
                    int conversionFailedCount = converter.GetFailureCount();
                    if (conversionFailedCount > 0)
                        MessageBox.Show(string.Format("Process Complete. {0} file(s) could not be converted (missing .ftexs).", conversionFailedCount), "Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Done!", "Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Please select an output folder.", "Missing Output Directory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Please select an input folder.", "Missing Input Directory", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
