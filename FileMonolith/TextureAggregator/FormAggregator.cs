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

namespace TextureAggregator
{
    public partial class FormAggregator : Form
    {
        private string pftxsFullPath = "";

        public FormAggregator()
        {
            InitializeComponent();
            checkConvertDDS.Checked = true;
            buttonAggregate.Enabled = false;

            if (!checkTPPMasterFileListExists())
                return;

            string defaultOutputDir = Properties.Settings.Default.outputDirectory;
            if (!string.IsNullOrEmpty(defaultOutputDir))
            {
                if (Directory.Exists(defaultOutputDir))
                {
                    textOutDir.Text = defaultOutputDir;
                }
            }
            string defaultTextureDir = Properties.Settings.Default.textureDirectory;
            if (!string.IsNullOrEmpty(defaultTextureDir))
            {
                if (Directory.Exists(defaultTextureDir))
                {
                    textArchiveDir.Text = defaultTextureDir;
                }
            }
            string defaultpftxs = Properties.Settings.Default.inputPftxs;
            if (!string.IsNullOrEmpty(defaultpftxs))
            {
                if (Directory.Exists(defaultpftxs))
                {
                    pftxsFullPath = defaultpftxs;
                    textPftxs.Text = Path.GetFileName(pftxsFullPath);
                }
            }
        }

        private bool checkTPPMasterFileListExists()
        {
            if (!File.Exists("TppMasterFileList.txt"))
            {
                MessageBox.Show("TppMasterFileList.txt is missing from the application folder. This tool cannot build directory structures without TppMasterFileList.txt.", "Missing TppMasterFileList.txt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void checkConvertDDS_CheckedChanged(object sender, EventArgs e)
        {
            labelOutDir.Text = checkConvertDDS.Checked ? "Output Folder [.ftex/.ftexs/.dds]:" : "Output Folder [.ftex/.ftexs]:";
        }

        private bool updateProcessButton()
        {
            bool archiveReady = textArchiveDir.Text != "";
            bool pftxsReady = textPftxs.Text != "";
            bool outputReady = textOutDir.Text != "";

            buttonAggregate.Enabled = archiveReady && pftxsReady && outputReady;
            return buttonAggregate.Enabled;
        }

        private void textArchiveDir_TextChanged(object sender, EventArgs e)
        {
            updateProcessButton();
        }

        private void textOutDir_TextChanged(object sender, EventArgs e)
        {
            updateProcessButton();
        }

        private void textPftxs_TextChanged(object sender, EventArgs e)
        {
            updateProcessButton();
        }

        private void buttonPftxs_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            inputFileDialog.Filter = "Packed Fox Textures (*.pftxs)|*.pftxs";

            string inputDirectory = Properties.Settings.Default.inputPftxs;
            if (!string.IsNullOrEmpty(inputDirectory))
            {
                if (Directory.Exists(inputDirectory))
                {
                    inputFileDialog.InitialDirectory = inputDirectory;
                }
            }

            DialogResult selectionResult = inputFileDialog.ShowDialog();
            if (selectionResult != DialogResult.OK) return;

            pftxsFullPath = inputFileDialog.FileName;

            Properties.Settings.Default.inputPftxs = pftxsFullPath;
            Properties.Settings.Default.Save();
            
            textPftxs.Text = Path.GetFileName(pftxsFullPath);
        }

        private void buttonOutDir_Click(object sender, EventArgs e)
        {
            FolderSelectDialog selectionDialog = new FolderSelectDialog();
            selectionDialog.Title = "Choose a folder where the files will be copied to. Making a new folder is highly recommended.";

            string defaultOutputDir = Properties.Settings.Default.outputDirectory;
            if (!string.IsNullOrEmpty(defaultOutputDir))
            {
                if (Directory.Exists(defaultOutputDir))
                {
                    selectionDialog.InitialDirectory = defaultOutputDir;
                }
            }

            if (selectionDialog.ShowDialog() != true) return;
            string directoryPath = selectionDialog.FileName;

            if (!string.IsNullOrEmpty(directoryPath))
            {
                Properties.Settings.Default.outputDirectory = directoryPath;
                Properties.Settings.Default.Save();
            }

            textOutDir.Text = directoryPath;
        }

        private void buttonArchiveDir_Click(object sender, EventArgs e)
        {
            FolderSelectDialog selectionDialog = new FolderSelectDialog();
            selectionDialog.Title = "Choose a folder where vanilla .ftex and .ftexs files can be copied from. The tool will search subfolders as well.";

            string defaultTextureDir = Properties.Settings.Default.textureDirectory;
            if (!string.IsNullOrEmpty(defaultTextureDir))
            {
                if (Directory.Exists(defaultTextureDir))
                {
                    selectionDialog.InitialDirectory = defaultTextureDir;
                }
            }

            if (selectionDialog.ShowDialog() != true) return;
            string directoryPath = selectionDialog.FileName;

            if (!string.IsNullOrEmpty(directoryPath))
            {
                Properties.Settings.Default.textureDirectory = directoryPath;
                Properties.Settings.Default.Save();
            }
            
            textArchiveDir.Text = directoryPath;
        }

        private void buttonAggregate_Click(object sender, EventArgs e)
        {
            if (!checkTPPMasterFileListExists())
                return;

            


        }
    }
}
