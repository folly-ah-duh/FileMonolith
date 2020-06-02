using System;
using System.Windows.Forms;

namespace TextureAggregator
{
    public partial class FormProcessing : Form
    {
        public FormProcessing()
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
