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
            labelCurrentFile.Invoke(new Action(() => labelCurrentFile.Text = e.Feedback));
        }
    }
}
