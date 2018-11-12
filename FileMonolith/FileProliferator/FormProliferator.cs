using FolderSelect;
using ProcessWindow;
using System;
using System.IO;
using System.Windows.Forms;

namespace FileProliferator
{
    public partial class FormProliferator : Form
    {
        public FormProliferator()
        {
            InitializeComponent();
            buttonRefFile.Enabled = false;
            checkRefFile.Checked = false;
            buttonTextureDir.Enabled = false;
            checkPullTextures.Checked = false;


            if (!File.Exists("TppMasterFileList.txt"))
            {
                MessageBox.Show("TppMasterFile.txt is missing from the application folder. This tool cannot build directory structures without TppMasterFile.txt.", "Missing TppMasterFile.txt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private string[] selectedFilePaths { get; set; }

        private string referenceFileName { get; set; }

        private string outputDirectory { get; set; }

        private string VanillaTexturesPath { get; set; }

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
            selectionDialog.Title = "Choose a folder where the MakeBite structure will be built. Making a new folder is highly recommended.";
            if (textOutDir.Text != null)
                selectionDialog.InitialDirectory = textOutDir.Text;
            if (selectionDialog.ShowDialog() != true) return;
            string directoryPath = selectionDialog.FileName;

            outputDirectory = directoryPath;
            textOutDir.Text = directoryPath;
        }

        private void checkPullTextures_CheckedChanged(object sender, EventArgs e)
        {
            buttonTextureDir.Enabled = checkPullTextures.Checked;
        }

        private void buttonTextureDir_Click(object sender, EventArgs e)
        {
            FolderSelectDialog selectionDialog = new FolderSelectDialog();
            selectionDialog.Title = "Choose a folder where vanilla .ftex and .ftexs files can be copied from. The tool will search subfolders as well.";
            if (textTextureDir.Text != null)
                selectionDialog.InitialDirectory = textTextureDir.Text;
            if (selectionDialog.ShowDialog() != true) return;
            string directoryPath = selectionDialog.FileName;

            VanillaTexturesPath = directoryPath;
            textTextureDir.Text = directoryPath;
        }

        private void buttonProliferate_Click(object sender, EventArgs e)
        {

            if (!File.Exists("TppMasterFileList.txt"))
            {
                MessageBox.Show("TppMasterFile.txt is missing from the File Proliferator.exe folder.", "Missing TppMasterFile.txt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedFilePaths == null)
            {
                MessageBox.Show("Please choose file(s) to build directories for.", "No Files Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (outputDirectory == null)
            {
                MessageBox.Show("Please select an output folder.", "Missing Output Directory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (checkRefFile.Checked && referenceFileName == null)
            {
                MessageBox.Show("Please select a Reference File.", "No Reference File Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (checkPullTextures.Checked && VanillaTexturesPath == null)
            {
                MessageBox.Show("Please set a Texture Directory.", "No Reference File Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TextureManager textureManager = new TextureManager();
            ProliferateManager proliferator = new ProliferateManager();
            FormProcessingProliferation processWindow = new FormProcessingProliferation();
            proliferator.SendFeedback += processWindow.OnSendFeedback;
            textureManager.SendFeedback += processWindow.OnSendFeedback;

            if (checkConvertDds.Checked)
            {
                ProcessingWindow.Show(processWindow, new Action((MethodInvoker)delegate { selectedFilePaths = textureManager.convertDdsToFtex(selectedFilePaths); }));
            }

            int ddsConversionFailedCount = textureManager.getConversionFailedCount();
            if (ddsConversionFailedCount > 0)
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("There were {0} .dds file(s) that failed to convert to .ftex formatting. Unconverted .dds files will not be included in the Directory Structure.\n\nWould you still like to build the Directory Structure?", ddsConversionFailedCount), "Missing _pftxs Textures", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult != DialogResult.Yes)
                    return;
            }

            if (!checkRefFile.Checked)
            {
                ProcessingWindow.Show(processWindow, new Action((MethodInvoker)delegate { proliferator.DoProliferate(selectedFilePaths, outputDirectory); }));
            }
            else
            {
                ProcessingWindow.Show(processWindow, new Action((MethodInvoker)delegate { proliferator.DoProliferateFromReference(selectedFilePaths, outputDirectory, referenceFileName); }));
            }

            if (checkPullTextures.Checked)
            {
                if (checkRefFile.Checked)
                {
                    ProcessingWindow.Show(processWindow, new Action((MethodInvoker)delegate { textureManager.PullVanillaTextures(outputDirectory, VanillaTexturesPath, referenceFileName); }));
                }
                else
                {
                    ProcessingWindow.Show(processWindow, new Action((MethodInvoker)delegate { textureManager.PullVanillaTextures(outputDirectory, VanillaTexturesPath, selectedFilePaths); }));
                }

            }

            int texturePullsFailed = textureManager.getTextureNotFoundCount();
            if (checkPackPftxs.Checked)
            {
                bool doPftxsPack = true;

                if(texturePullsFailed > 0)
                {
                    DialogResult dialogResult = MessageBox.Show(string.Format("There are {0} texture file(s) that could not be found in {1}. These textures were not pulled into the _pftxs folder(s).\n\nWould you still like to pack the _pftxs folders into .pftxs files?", texturePullsFailed, Path.GetFileName(VanillaTexturesPath)), "Missing _pftxs Textures", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    doPftxsPack = (dialogResult == DialogResult.Yes);
                }

                if (doPftxsPack)
                {
                    ProcessingWindow.Show(processWindow, new Action((MethodInvoker)delegate { textureManager.PackPftxsFolders(outputDirectory); }));
                }
            }

            if (texturePullsFailed > 0)
            {
                MessageBox.Show(string.Format("Process Complete. There were {0} texture file(s) that could not be found in {1}.\n\nThese textures were not pulled into the _pftxs folder(s).", texturePullsFailed, Path.GetFileName(VanillaTexturesPath)), "Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Done!", "Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
