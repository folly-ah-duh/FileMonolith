using FolderSelect;
using ProcessWindow;
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
                if (Directory.Exists(Path.GetDirectoryName(defaultpftxs)))
                {
                    pftxsFullPath = defaultpftxs;
                    if (File.Exists(pftxsFullPath))
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
            
            if (!string.IsNullOrEmpty(pftxsFullPath))
            {
                string initialD = Path.GetDirectoryName(pftxsFullPath);
                if (Directory.Exists(initialD))
                {
                    inputFileDialog.InitialDirectory = initialD;
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

            UnpackManager unpacker = new UnpackManager();
            AggregateManager aggregator = new AggregateManager();
            ConvertManager converter = new ConvertManager();
            FormProcessing processWindow = new FormProcessing();

            unpacker.SendFeedback += processWindow.OnSendFeedback;
            aggregator.SendFeedback += processWindow.OnSendFeedback;
            converter.SendFeedback += processWindow.OnSendFeedback;

            string[] ftexPathsNoExt = { };
            ProcessingWindow.Show(processWindow, new Action((MethodInvoker)delegate { ftexPathsNoExt = unpacker.DoUnpack(pftxsFullPath, textOutDir.Text); }));
            ProcessingWindow.Show(processWindow, new Action((MethodInvoker)delegate { aggregator.DoAggregate(ftexPathsNoExt, textArchiveDir.Text, textOutDir.Text); }));

            if (checkConvertDDS.Checked)
            {
                ProcessingWindow.Show(processWindow, new Action((MethodInvoker)delegate { converter.DoMassConversion(textOutDir.Text, textOutDir.Text, true); })); // TODO toggle true false for subfolder retention
            }

        }
    }
}
