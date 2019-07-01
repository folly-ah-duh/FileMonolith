using System;
using System.Windows.Forms;

namespace FileProliferator
{
    public partial class FormProcessingProliferation : Form
    {
        public FormProcessingProliferation()
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
                MessageBox.Show("Exception occurred during proliferation: \n" + (Exception)e.Feedback);
            }
        }
    }
}
