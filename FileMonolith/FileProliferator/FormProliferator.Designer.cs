namespace FileProliferator
{
    partial class FormProliferator
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
            this.buttonFiles = new System.Windows.Forms.Button();
            this.textFiles = new System.Windows.Forms.TextBox();
            this.labelFiles = new System.Windows.Forms.Label();
            this.buttonProliferate = new System.Windows.Forms.Button();
            this.checkRefFile = new System.Windows.Forms.CheckBox();
            this.textRefFile = new System.Windows.Forms.TextBox();
            this.buttonRefFile = new System.Windows.Forms.Button();
            this.labelOutDir = new System.Windows.Forms.Label();
            this.buttonOutDir = new System.Windows.Forms.Button();
            this.textOutDir = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonFiles
            // 
            this.buttonFiles.Location = new System.Drawing.Point(463, 23);
            this.buttonFiles.Name = "buttonFiles";
            this.buttonFiles.Size = new System.Drawing.Size(29, 23);
            this.buttonFiles.TabIndex = 0;
            this.buttonFiles.Text = "...";
            this.buttonFiles.UseVisualStyleBackColor = true;
            this.buttonFiles.Click += new System.EventHandler(this.buttonFiles_Click);
            // 
            // textFiles
            // 
            this.textFiles.Enabled = false;
            this.textFiles.Location = new System.Drawing.Point(12, 25);
            this.textFiles.Name = "textFiles";
            this.textFiles.Size = new System.Drawing.Size(445, 20);
            this.textFiles.TabIndex = 1;
            // 
            // labelFiles
            // 
            this.labelFiles.AutoSize = true;
            this.labelFiles.Location = new System.Drawing.Point(12, 9);
            this.labelFiles.Name = "labelFiles";
            this.labelFiles.Size = new System.Drawing.Size(31, 13);
            this.labelFiles.TabIndex = 2;
            this.labelFiles.Text = "Files:";
            // 
            // buttonProliferate
            // 
            this.buttonProliferate.Location = new System.Drawing.Point(350, 162);
            this.buttonProliferate.Name = "buttonProliferate";
            this.buttonProliferate.Size = new System.Drawing.Size(142, 33);
            this.buttonProliferate.TabIndex = 3;
            this.buttonProliferate.Text = "Build Directory Structure...";
            this.buttonProliferate.UseVisualStyleBackColor = true;
            this.buttonProliferate.Click += new System.EventHandler(this.buttonProliferate_Click);
            // 
            // checkRefFile
            // 
            this.checkRefFile.AutoSize = true;
            this.checkRefFile.Location = new System.Drawing.Point(12, 57);
            this.checkRefFile.Name = "checkRefFile";
            this.checkRefFile.Size = new System.Drawing.Size(333, 17);
            this.checkRefFile.TabIndex = 4;
            this.checkRefFile.Text = "Use Reference File (copy files to anywhere that contains this file):";
            this.checkRefFile.UseVisualStyleBackColor = true;
            this.checkRefFile.CheckedChanged += new System.EventHandler(this.checkRefFile_CheckedChanged);
            // 
            // textRefFile
            // 
            this.textRefFile.Enabled = false;
            this.textRefFile.Location = new System.Drawing.Point(12, 80);
            this.textRefFile.Name = "textRefFile";
            this.textRefFile.Size = new System.Drawing.Size(445, 20);
            this.textRefFile.TabIndex = 6;
            // 
            // buttonRefFile
            // 
            this.buttonRefFile.Location = new System.Drawing.Point(463, 78);
            this.buttonRefFile.Name = "buttonRefFile";
            this.buttonRefFile.Size = new System.Drawing.Size(29, 23);
            this.buttonRefFile.TabIndex = 5;
            this.buttonRefFile.Text = "...";
            this.buttonRefFile.UseVisualStyleBackColor = true;
            this.buttonRefFile.Click += new System.EventHandler(this.buttonRefFile_Click);
            // 
            // labelOutDir
            // 
            this.labelOutDir.AutoSize = true;
            this.labelOutDir.Location = new System.Drawing.Point(12, 119);
            this.labelOutDir.Name = "labelOutDir";
            this.labelOutDir.Size = new System.Drawing.Size(74, 13);
            this.labelOutDir.TabIndex = 11;
            this.labelOutDir.Text = "Output Folder:";
            // 
            // buttonOutDir
            // 
            this.buttonOutDir.Location = new System.Drawing.Point(463, 133);
            this.buttonOutDir.Name = "buttonOutDir";
            this.buttonOutDir.Size = new System.Drawing.Size(29, 23);
            this.buttonOutDir.TabIndex = 10;
            this.buttonOutDir.Text = "...";
            this.buttonOutDir.UseVisualStyleBackColor = true;
            this.buttonOutDir.Click += new System.EventHandler(this.buttonOutDir_Click);
            // 
            // textOutDir
            // 
            this.textOutDir.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textOutDir.Enabled = false;
            this.textOutDir.Location = new System.Drawing.Point(12, 135);
            this.textOutDir.Name = "textOutDir";
            this.textOutDir.ReadOnly = true;
            this.textOutDir.Size = new System.Drawing.Size(445, 20);
            this.textOutDir.TabIndex = 9;
            // 
            // FormProliferator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 207);
            this.Controls.Add(this.labelOutDir);
            this.Controls.Add(this.buttonOutDir);
            this.Controls.Add(this.textOutDir);
            this.Controls.Add(this.textRefFile);
            this.Controls.Add(this.buttonRefFile);
            this.Controls.Add(this.checkRefFile);
            this.Controls.Add(this.buttonProliferate);
            this.Controls.Add(this.labelFiles);
            this.Controls.Add(this.textFiles);
            this.Controls.Add(this.buttonFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormProliferator";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Proliferator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFiles;
        private System.Windows.Forms.TextBox textFiles;
        private System.Windows.Forms.Label labelFiles;
        private System.Windows.Forms.Button buttonProliferate;
        private System.Windows.Forms.CheckBox checkRefFile;
        private System.Windows.Forms.TextBox textRefFile;
        private System.Windows.Forms.Button buttonRefFile;
        private System.Windows.Forms.Label labelOutDir;
        private System.Windows.Forms.Button buttonOutDir;
        private System.Windows.Forms.TextBox textOutDir;
    }
}

