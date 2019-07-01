using System;
using System.Windows.Forms;

namespace ArchiveUnpacker
{
    public partial class FormProcessesingUnpack : Form
    {
        public FormProcessesingUnpack()
        {
            InitializeComponent();
        }
        public void OnSendFeedback(object source, FeedbackEventArgs e)
        {
            try
            {
                labelCurrentFile.Invoke(new Action(() => labelCurrentFile.Text = (string)e.Feedback));
            }
            catch
            {
                MessageBox.Show("Exception occurred during unpack: \n" + (Exception)e.Feedback);
            }
        }
    }
}
