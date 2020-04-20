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
using ProcessWindow;

namespace ArchiveTransferrer
{
    public partial class FormTransferrer : Form
    {
        string gzTextureG0s;
        string mgoTextureDat;
        string tppMasterDir;

        public FormTransferrer()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

            TransferManager transferrer = new TransferManager();
            FormProcessingTransfer processWindow = new FormProcessingTransfer();
            transferrer.SendFeedback += processWindow.OnSendFeedback;

            ProcessingWindow.Show(processWindow, new Action((MethodInvoker)delegate { transferrer.Transfer(gzTextureG0s, mgoTextureDat, tppMasterDir); }));

        }

        private void buttonGZEXE_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputDialog = new OpenFileDialog();
            inputDialog.Filter = "GZ Executable|MgsGroundZeroes.exe";
            inputDialog.Multiselect = false;

            DialogResult selectionResult = inputDialog.ShowDialog();
            if (selectionResult != DialogResult.OK)
            {
                //labelGZFOUND.Text = "";
                //textGZEXE.Text = "";
                return;
            }

            textGZEXE.Text = inputDialog.FileName;

            gzTextureG0s = Path.Combine(Path.GetDirectoryName(textGZEXE.Text), "data_01.g0s");
            if (File.Exists(gzTextureG0s))
            {
                labelGZFOUND.Text = "'data_01.g0s' Found!";
                labelGZFOUND.ForeColor = Color.ForestGreen;
            }
            else
            {
                labelGZFOUND.Text = "'data_01.g0s' Not Found!";
                labelGZFOUND.ForeColor = Color.Red;
            }

            updateTransferButton();
        }

        private void buttonTPPEXE_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputDialog = new OpenFileDialog();
            inputDialog.Filter = "TPP Executable|mgsvtpp.exe";
            inputDialog.Multiselect = false;

            DialogResult selectionResult = inputDialog.ShowDialog();
            if (selectionResult != DialogResult.OK)
            {
                //labelMGOFOUND.Text = "";
                //textTPPEXE.Text = "";
                return;
            }

            textTPPEXE.Text = inputDialog.FileName;

            mgoTextureDat = Path.Combine(Path.GetDirectoryName(textTPPEXE.Text), "mgo\\texture0.dat");
            if (File.Exists(mgoTextureDat))
            {
                labelMGOFOUND.Text = "'mgo/texture0.dat' Found!";
                labelMGOFOUND.ForeColor = Color.ForestGreen;
            }
            else
            {
                labelMGOFOUND.Text = "'mgo/texture0.dat' Not Found!";
                labelMGOFOUND.ForeColor = Color.Red;
            }

            tppMasterDir = Path.Combine(Path.GetDirectoryName(textTPPEXE.Text), "master");

            updateTransferButton();
        }

        private void updateTransferButton()
        {
            bool g0sReady = textGZEXE.Text != "" && File.Exists(gzTextureG0s);
            bool mgoReady = textTPPEXE.Text != "" && File.Exists(mgoTextureDat);
            bool masterExists = Directory.Exists(tppMasterDir);

            buttonStart.Enabled = g0sReady && mgoReady && masterExists;
            Console.WriteLine(gzTextureG0s + " | " + mgoTextureDat + " | " + tppMasterDir);
        }
        
    }
}
