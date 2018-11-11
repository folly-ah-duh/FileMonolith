using System;
using System.Windows.Forms;

namespace MassTextureConverter
{
    public partial class FormProcessingConversion : Form
    {
        public FormProcessingConversion()
        {
            InitializeComponent();
        }
        public void OnSendFeedback(object source, FeedbackEventArgs e)
        {
            labelCurrentFile.Invoke(new Action(() => labelCurrentFile.Text = e.Feedback));
        }
    }
}
