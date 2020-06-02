namespace FilenameUpdater
{
    partial class FormUpdater
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
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelOutDir = new System.Windows.Forms.Label();
            this.labelInFiles = new System.Windows.Forms.Label();
            this.buttonInFiles = new System.Windows.Forms.Button();
            this.buttonOutDir = new System.Windows.Forms.Button();
            this.textOutDir = new System.Windows.Forms.TextBox();
            this.textInFiles = new System.Windows.Forms.TextBox();
            this.checkIncludeDirs = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(364, 117);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(128, 33);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "Update Filenames";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // labelOutDir
            // 
            this.labelOutDir.AutoSize = true;
            this.labelOutDir.Location = new System.Drawing.Point(12, 58);
            this.labelOutDir.Name = "labelOutDir";
            this.labelOutDir.Size = new System.Drawing.Size(74, 13);
            this.labelOutDir.TabIndex = 21;
            this.labelOutDir.Text = "Output Folder:";
            // 
            // labelInFiles
            // 
            this.labelInFiles.AutoSize = true;
            this.labelInFiles.Location = new System.Drawing.Point(12, 9);
            this.labelInFiles.Name = "labelInFiles";
            this.labelInFiles.Size = new System.Drawing.Size(31, 13);
            this.labelInFiles.TabIndex = 20;
            this.labelInFiles.Text = "Files:";
            // 
            // buttonInFiles
            // 
            this.buttonInFiles.Location = new System.Drawing.Point(463, 23);
            this.buttonInFiles.Name = "buttonInFiles";
            this.buttonInFiles.Size = new System.Drawing.Size(29, 23);
            this.buttonInFiles.TabIndex = 17;
            this.buttonInFiles.Text = "...";
            this.buttonInFiles.UseVisualStyleBackColor = true;
            this.buttonInFiles.Click += new System.EventHandler(this.buttonInFiles_Click);
            // 
            // buttonOutDir
            // 
            this.buttonOutDir.Location = new System.Drawing.Point(463, 72);
            this.buttonOutDir.Name = "buttonOutDir";
            this.buttonOutDir.Size = new System.Drawing.Size(29, 23);
            this.buttonOutDir.TabIndex = 19;
            this.buttonOutDir.Text = "...";
            this.buttonOutDir.UseVisualStyleBackColor = true;
            this.buttonOutDir.Click += new System.EventHandler(this.buttonOutDir_Click);
            // 
            // textOutDir
            // 
            this.textOutDir.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textOutDir.Enabled = false;
            this.textOutDir.Location = new System.Drawing.Point(12, 74);
            this.textOutDir.Name = "textOutDir";
            this.textOutDir.ReadOnly = true;
            this.textOutDir.Size = new System.Drawing.Size(445, 20);
            this.textOutDir.TabIndex = 18;
            // 
            // textInFiles
            // 
            this.textInFiles.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textInFiles.Enabled = false;
            this.textInFiles.Location = new System.Drawing.Point(12, 25);
            this.textInFiles.Name = "textInFiles";
            this.textInFiles.ReadOnly = true;
            this.textInFiles.Size = new System.Drawing.Size(445, 20);
            this.textInFiles.TabIndex = 16;
            // 
            // checkIncludeDirs
            // 
            this.checkIncludeDirs.AutoSize = true;
            this.checkIncludeDirs.Location = new System.Drawing.Point(12, 126);
            this.checkIncludeDirs.Name = "checkIncludeDirs";
            this.checkIncludeDirs.Size = new System.Drawing.Size(152, 17);
            this.checkIncludeDirs.TabIndex = 22;
            this.checkIncludeDirs.Text = "Include Directory Structure";
            this.checkIncludeDirs.UseVisualStyleBackColor = true;
            // 
            // FormUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 162);
            this.Controls.Add(this.checkIncludeDirs);
            this.Controls.Add(this.labelOutDir);
            this.Controls.Add(this.labelInFiles);
            this.Controls.Add(this.buttonInFiles);
            this.Controls.Add(this.buttonOutDir);
            this.Controls.Add(this.textOutDir);
            this.Controls.Add(this.textInFiles);
            this.Controls.Add(this.buttonUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormUpdater";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filename Updater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelOutDir;
        private System.Windows.Forms.Label labelInFiles;
        private System.Windows.Forms.Button buttonInFiles;
        private System.Windows.Forms.Button buttonOutDir;
        private System.Windows.Forms.TextBox textOutDir;
        private System.Windows.Forms.TextBox textInFiles;
        private System.Windows.Forms.CheckBox checkIncludeDirs;
    }
}

