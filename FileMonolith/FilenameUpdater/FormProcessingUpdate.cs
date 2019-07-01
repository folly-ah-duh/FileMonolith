using System;
using System.Windows.Forms;

namespace FilenameUpdater
{
    public partial class FormProcessingUpdate : Form
    {
        public FormProcessingUpdate()
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
                MessageBox.Show("Exception occurred during update: \n" + (Exception)e.Feedback);
            }
        }
    }
}
