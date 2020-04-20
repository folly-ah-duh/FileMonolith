using System;
using System.Windows.Forms;

namespace ArchiveTransferrer
{
    public partial class FormProcessingTransfer : Form
    {
        public FormProcessingTransfer()
        {
            InitializeComponent();
        }

        public void OnSendFeedback(object source, FeedbackEventArgs e)
        {
            try
            {
                labelCurrentWork.Invoke(new Action(() => labelCurrentWork.Text = (string)e.Feedback));
            }
            catch
            {
                MessageBox.Show("Exception occurred during transfer: \n" + (Exception)e.Feedback);
            }
        }
    }
}
