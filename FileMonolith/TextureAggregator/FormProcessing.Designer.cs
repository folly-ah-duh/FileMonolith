namespace TextureAggregator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProcessing));
            this.pictureSpiral = new System.Windows.Forms.PictureBox();
            this.labelCurrentWork = new System.Windows.Forms.Label();
            this.labelUpdate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSpiral)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureSpiral
            // 
            this.pictureSpiral.Image = ((System.Drawing.Image)(resources.GetObject("pictureSpiral.Image")));
            this.pictureSpiral.Location = new System.Drawing.Point(12, 8);
            this.pictureSpiral.Name = "pictureSpiral";
            this.pictureSpiral.Size = new System.Drawing.Size(36, 35);
            this.pictureSpiral.TabIndex = 8;
            this.pictureSpiral.TabStop = false;
            // 
            // labelCurrentWork
            // 
            this.labelCurrentWork.Location = new System.Drawing.Point(12, 46);
            this.labelCurrentWork.Name = "labelCurrentWork";
            this.labelCurrentWork.Size = new System.Drawing.Size(306, 43);
            this.labelCurrentWork.TabIndex = 7;
            this.labelCurrentWork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelUpdate
            // 
            this.labelUpdate.Location = new System.Drawing.Point(12, 8);
            this.labelUpdate.Name = "labelUpdate";
            this.labelUpdate.Size = new System.Drawing.Size(306, 23);
            this.labelUpdate.TabIndex = 6;
            this.labelUpdate.Text = "Processing, please wait...";
            this.labelUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 82);
            this.ControlBox = false;
            this.Controls.Add(this.pictureSpiral);
            this.Controls.Add(this.labelCurrentWork);
            this.Controls.Add(this.labelUpdate);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProcessing";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Processing...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureSpiral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureSpiral;
        private System.Windows.Forms.Label labelCurrentWork;
        private System.Windows.Forms.Label labelUpdate;
    }
}