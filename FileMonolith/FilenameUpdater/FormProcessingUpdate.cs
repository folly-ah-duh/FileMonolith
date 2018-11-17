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
            labelCurrentFile.Invoke(new Action(() => labelCurrentFile.Text = e.Feedback));
        }
    }
}
