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
            this.textRefFile = new System.Windows.Forms.TextBox();
            this.buttonRefFile = new System.Windows.Forms.Button();
            this.labelOutDir = new System.Windows.Forms.Label();
            this.buttonOutDir = new System.Windows.Forms.Button();
            this.textOutDir = new System.Windows.Forms.TextBox();
            this.groupTextureOptions = new System.Windows.Forms.GroupBox();
            this.checkPackPftxs = new System.Windows.Forms.CheckBox();
            this.checkPullTextures = new System.Windows.Forms.CheckBox();
            this.checkConvertDds = new System.Windows.Forms.CheckBox();
            this.buttonTextureDir = new System.Windows.Forms.Button();
            this.textTextureDir = new System.Windows.Forms.TextBox();
            this.groupStructureOptions = new System.Windows.Forms.GroupBox();
            this.checkSetRefRoot = new System.Windows.Forms.CheckBox();
            this.checkRefFile = new System.Windows.Forms.CheckBox();
            this.checkNameUpdates = new System.Windows.Forms.CheckBox();
            this.groupTextureOptions.SuspendLayout();
            this.groupStructureOptions.SuspendLayout();
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
            this.buttonProliferate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProliferate.Location = new System.Drawing.Point(346, 95);
            this.buttonProliferate.Name = "buttonProliferate";
            this.buttonProliferate.Size = new System.Drawing.Size(146, 33);
            this.buttonProliferate.TabIndex = 3;
            this.buttonProliferate.Text = "Proliferate Files";
            this.buttonProliferate.UseVisualStyleBackColor = true;
            this.buttonProliferate.Click += new System.EventHandler(this.buttonProliferate_Click);
            // 
            // textRefFile
            // 
            this.textRefFile.Enabled = false;
            this.textRefFile.Location = new System.Drawing.Point(6, 42);
            this.textRefFile.Name = "textRefFile";
            this.textRefFile.Size = new System.Drawing.Size(322, 20);
            this.textRefFile.TabIndex = 6;
            // 
            // buttonRefFile
            // 
            this.buttonRefFile.Location = new System.Drawing.Point(334, 40);
            this.buttonRefFile.Name = "buttonRefFile";
            this.buttonRefFile.Size = new System.Drawing.Size(140, 23);
            this.buttonRefFile.TabIndex = 5;
            this.buttonRefFile.Text = "Set Reference File...";
            this.buttonRefFile.UseVisualStyleBackColor = true;
            this.buttonRefFile.Click += new System.EventHandler(this.buttonRefFile_Click);
            // 
            // labelOutDir
            // 
            this.labelOutDir.AutoSize = true;
            this.labelOutDir.Location = new System.Drawing.Point(12, 50);
            this.labelOutDir.Name = "labelOutDir";
            this.labelOutDir.Size = new System.Drawing.Size(74, 13);
            this.labelOutDir.TabIndex = 11;
            this.labelOutDir.Text = "Output Folder:";
            // 
            // buttonOutDir
            // 
            this.buttonOutDir.Location = new System.Drawing.Point(463, 64);
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
            this.textOutDir.Location = new System.Drawing.Point(12, 66);
            this.textOutDir.Name = "textOutDir";
            this.textOutDir.ReadOnly = true;
            this.textOutDir.Size = new System.Drawing.Size(445, 20);
            this.textOutDir.TabIndex = 9;
            // 
            // groupTextureOptions
            // 
            this.groupTextureOptions.Controls.Add(this.checkPackPftxs);
            this.groupTextureOptions.Controls.Add(this.checkPullTextures);
            this.groupTextureOptions.Controls.Add(this.checkConvertDds);
            this.groupTextureOptions.Controls.Add(this.buttonTextureDir);
            this.groupTextureOptions.Controls.Add(this.textTextureDir);
            this.groupTextureOptions.Location = new System.Drawing.Point(12, 216);
            this.groupTextureOptions.Name = "groupTextureOptions";
            this.groupTextureOptions.Size = new System.Drawing.Size(480, 68);
            this.groupTextureOptions.TabIndex = 12;
            this.groupTextureOptions.TabStop = false;
            this.groupTextureOptions.Text = "Texture Options";
            // 
            // checkPackPftxs
            // 
            this.checkPackPftxs.AutoSize = true;
            this.checkPackPftxs.Location = new System.Drawing.Point(373, 19);
            this.checkPackPftxs.Name = "checkPackPftxs";
            this.checkPackPftxs.Size = new System.Drawing.Size(82, 17);
            this.checkPackPftxs.TabIndex = 13;
            this.checkPackPftxs.Text = "Pack _pftxs";
            this.checkPackPftxs.UseVisualStyleBackColor = true;
            // 
            // checkPullTextures
            // 
            this.checkPullTextures.AutoSize = true;
            this.checkPullTextures.Location = new System.Drawing.Point(6, 19);
            this.checkPullTextures.Name = "checkPullTextures";
            this.checkPullTextures.Size = new System.Drawing.Size(176, 17);
            this.checkPullTextures.TabIndex = 16;
            this.checkPullTextures.Text = "Pull Vanilla .ftex | .ftexs to _pftxs";
            this.checkPullTextures.UseVisualStyleBackColor = true;
            this.checkPullTextures.CheckedChanged += new System.EventHandler(this.checkPullTextures_CheckedChanged);
            // 
            // checkConvertDds
            // 
            this.checkConvertDds.AutoSize = true;
            this.checkConvertDds.Location = new System.Drawing.Point(213, 19);
            this.checkConvertDds.Name = "checkConvertDds";
            this.checkConvertDds.Size = new System.Drawing.Size(121, 17);
            this.checkConvertDds.TabIndex = 15;
            this.checkConvertDds.Text = "Convert .dds to .ftex";
            this.checkConvertDds.UseVisualStyleBackColor = true;
            // 
            // buttonTextureDir
            // 
            this.buttonTextureDir.Location = new System.Drawing.Point(334, 40);
            this.buttonTextureDir.Name = "buttonTextureDir";
            this.buttonTextureDir.Size = new System.Drawing.Size(140, 23);
            this.buttonTextureDir.TabIndex = 14;
            this.buttonTextureDir.Text = "Set Archives Directory...";
            this.buttonTextureDir.UseVisualStyleBackColor = true;
            this.buttonTextureDir.Click += new System.EventHandler(this.buttonTextureDir_Click);
            // 
            // textTextureDir
            // 
            this.textTextureDir.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textTextureDir.Enabled = false;
            this.textTextureDir.Location = new System.Drawing.Point(6, 42);
            this.textTextureDir.Name = "textTextureDir";
            this.textTextureDir.ReadOnly = true;
            this.textTextureDir.Size = new System.Drawing.Size(322, 20);
            this.textTextureDir.TabIndex = 13;
            // 
            // groupStructureOptions
            // 
            this.groupStructureOptions.Controls.Add(this.checkSetRefRoot);
            this.groupStructureOptions.Controls.Add(this.checkRefFile);
            this.groupStructureOptions.Controls.Add(this.buttonRefFile);
            this.groupStructureOptions.Controls.Add(this.textRefFile);
            this.groupStructureOptions.Location = new System.Drawing.Point(12, 142);
            this.groupStructureOptions.Name = "groupStructureOptions";
            this.groupStructureOptions.Size = new System.Drawing.Size(480, 68);
            this.groupStructureOptions.TabIndex = 13;
            this.groupStructureOptions.TabStop = false;
            this.groupStructureOptions.Text = "Structure Options";
            // 
            // checkSetRefRoot
            // 
            this.checkSetRefRoot.AutoSize = true;
            this.checkSetRefRoot.Location = new System.Drawing.Point(350, 19);
            this.checkSetRefRoot.Name = "checkSetRefRoot";
            this.checkSetRefRoot.Size = new System.Drawing.Size(124, 17);
            this.checkSetRefRoot.TabIndex = 7;
            this.checkSetRefRoot.Text = "Set in Root of Packs";
            this.checkSetRefRoot.UseVisualStyleBackColor = true;
            // 
            // checkRefFile
            // 
            this.checkRefFile.AutoSize = true;
            this.checkRefFile.Location = new System.Drawing.Point(6, 19);
            this.checkRefFile.Name = "checkRefFile";
            this.checkRefFile.Size = new System.Drawing.Size(322, 17);
            this.checkRefFile.TabIndex = 4;
            this.checkRefFile.Text = "Use Reference File (Copy files anywhere that contains this file):";
            this.checkRefFile.UseVisualStyleBackColor = true;
            this.checkRefFile.CheckedChanged += new System.EventHandler(this.checkRefFile_CheckedChanged);
            // 
            // checkNameUpdates
            // 
            this.checkNameUpdates.AutoSize = true;
            this.checkNameUpdates.Location = new System.Drawing.Point(18, 95);
            this.checkNameUpdates.Name = "checkNameUpdates";
            this.checkNameUpdates.Size = new System.Drawing.Size(155, 17);
            this.checkNameUpdates.TabIndex = 8;
            this.checkNameUpdates.Text = "Check for filename updates";
            this.checkNameUpdates.UseVisualStyleBackColor = true;
            this.checkNameUpdates.CheckedChanged += new System.EventHandler(this.checkNameUpdates_CheckedChanged);
            // 
            // FormProliferator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 296);
            this.Controls.Add(this.checkNameUpdates);
            this.Controls.Add(this.groupStructureOptions);
            this.Controls.Add(this.groupTextureOptions);
            this.Controls.Add(this.labelOutDir);
            this.Controls.Add(this.buttonOutDir);
            this.Controls.Add(this.textOutDir);
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
            this.groupTextureOptions.ResumeLayout(false);
            this.groupTextureOptions.PerformLayout();
            this.groupStructureOptions.ResumeLayout(false);
            this.groupStructureOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFiles;
        private System.Windows.Forms.TextBox textFiles;
        private System.Windows.Forms.Label labelFiles;
        private System.Windows.Forms.Button buttonProliferate;
        private System.Windows.Forms.TextBox textRefFile;
        private System.Windows.Forms.Button buttonRefFile;
        private System.Windows.Forms.Label labelOutDir;
        private System.Windows.Forms.Button buttonOutDir;
        private System.Windows.Forms.TextBox textOutDir;
        private System.Windows.Forms.GroupBox groupTextureOptions;
        private System.Windows.Forms.CheckBox checkPackPftxs;
        private System.Windows.Forms.CheckBox checkPullTextures;
        private System.Windows.Forms.CheckBox checkConvertDds;
        private System.Windows.Forms.Button buttonTextureDir;
        private System.Windows.Forms.TextBox textTextureDir;
        private System.Windows.Forms.GroupBox groupStructureOptions;
        private System.Windows.Forms.CheckBox checkSetRefRoot;
        private System.Windows.Forms.CheckBox checkRefFile;
        private System.Windows.Forms.CheckBox checkNameUpdates;
    }
}

