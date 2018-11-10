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
            labelCurrentFile.Invoke(new Action(() => labelCurrentFile.Text = e.Feedback));
        }
    }
}
