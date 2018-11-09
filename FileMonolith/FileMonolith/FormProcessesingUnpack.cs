using System;
using System.Windows.Forms;

namespace FileMonolith
{
    public partial class FormProcessesingUnpack : Form
    {
        public FormProcessesingUnpack()
        {
            InitializeComponent();
        }
        public void OnSendFeedback(object source, FeedbackEventArgs e)
        {
            labelCurrentFile.Invoke(new Action(() => labelCurrentFile.Text = e.Feedback));
        }
    }
}
