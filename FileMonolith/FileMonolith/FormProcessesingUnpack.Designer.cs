namespace ArchiveUnpacker
{
    partial class FormProcessesingUnpack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProcessesingUnpack));
            this.labelUnpack = new System.Windows.Forms.Label();
            this.labelCurrentFile = new System.Windows.Forms.Label();
            this.pictureSpiral = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSpiral)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUnpack
            // 
            this.labelUnpack.Location = new System.Drawing.Point(12, 8);
            this.labelUnpack.Name = "labelUnpack";
            this.labelUnpack.Size = new System.Drawing.Size(306, 23);
            this.labelUnpack.TabIndex = 0;
            this.labelUnpack.Text = "Unpacking, please wait...";
            this.labelUnpack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCurrentFile
            // 
            this.labelCurrentFile.Location = new System.Drawing.Point(12, 46);
            this.labelCurrentFile.Name = "labelCurrentFile";
            this.labelCurrentFile.Size = new System.Drawing.Size(306, 43);
            this.labelCurrentFile.TabIndex = 1;
            this.labelCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureSpiral
            // 
            this.pictureSpiral.Image = ((System.Drawing.Image)(resources.GetObject("pictureSpiral.Image")));
            this.pictureSpiral.Location = new System.Drawing.Point(12, 8);
            this.pictureSpiral.Name = "pictureSpiral";
            this.pictureSpiral.Size = new System.Drawing.Size(36, 35);
            this.pictureSpiral.TabIndex = 2;
            this.pictureSpiral.TabStop = false;
            // 
            // FormProcessesingUnpack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 94);
            this.ControlBox = false;
            this.Controls.Add(this.pictureSpiral);
            this.Controls.Add(this.labelCurrentFile);
            this.Controls.Add(this.labelUnpack);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProcessesingUnpack";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Processing...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureSpiral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUnpack;
        private System.Windows.Forms.Label labelCurrentFile;
        private System.Windows.Forms.PictureBox pictureSpiral;
    }
}