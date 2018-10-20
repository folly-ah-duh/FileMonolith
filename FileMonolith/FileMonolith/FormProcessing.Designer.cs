namespace FileMonolith
{
    partial class FormProcessing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUnpack = new System.Windows.Forms.Label();
            this.labelCurrentFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUnpack
            // 
            this.labelUnpack.Location = new System.Drawing.Point(12, 9);
            this.labelUnpack.Name = "labelUnpack";
            this.labelUnpack.Size = new System.Drawing.Size(307, 23);
            this.labelUnpack.TabIndex = 0;
            this.labelUnpack.Text = "Unpacking...";
            this.labelUnpack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCurrentFile
            // 
            this.labelCurrentFile.Location = new System.Drawing.Point(12, 32);
            this.labelCurrentFile.Name = "labelCurrentFile";
            this.labelCurrentFile.Size = new System.Drawing.Size(307, 43);
            this.labelCurrentFile.TabIndex = 1;
            this.labelCurrentFile.Text = "[File Currently being unpacked]";
            this.labelCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 84);
            this.ControlBox = false;
            this.Controls.Add(this.labelCurrentFile);
            this.Controls.Add(this.labelUnpack);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProcessing";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Processing...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUnpack;
        private System.Windows.Forms.Label labelCurrentFile;
    }
}