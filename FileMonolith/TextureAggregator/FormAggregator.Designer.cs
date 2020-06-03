namespace TextureAggregator
{
    partial class FormAggregator
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
            this.checkConvertDDS = new System.Windows.Forms.CheckBox();
            this.labelOutDir = new System.Windows.Forms.Label();
            this.labelPftxs = new System.Windows.Forms.Label();
            this.buttonPftxs = new System.Windows.Forms.Button();
            this.buttonOutDir = new System.Windows.Forms.Button();
            this.textOutDir = new System.Windows.Forms.TextBox();
            this.textPftxs = new System.Windows.Forms.TextBox();
            this.buttonAggregate = new System.Windows.Forms.Button();
            this.buttonArchiveDir = new System.Windows.Forms.Button();
            this.textArchiveDir = new System.Windows.Forms.TextBox();
            this.textInFiles = new System.Windows.Forms.TextBox();
            this.checkDirStruc = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkConvertDDS
            // 
            this.checkConvertDDS.AutoSize = true;
            this.checkConvertDDS.Location = new System.Drawing.Point(12, 184);
            this.checkConvertDDS.Name = "checkConvertDDS";
            this.checkConvertDDS.Size = new System.Drawing.Size(137, 17);
            this.checkConvertDDS.TabIndex = 52;
            this.checkConvertDDS.Text = "Convert To .dds Format";
            this.checkConvertDDS.UseVisualStyleBackColor = true;
            this.checkConvertDDS.CheckedChanged += new System.EventHandler(this.checkConvertDDS_CheckedChanged);
            // 
            // labelOutDir
            // 
            this.labelOutDir.AutoSize = true;
            this.labelOutDir.Location = new System.Drawing.Point(12, 58);
            this.labelOutDir.Name = "labelOutDir";
            this.labelOutDir.Size = new System.Drawing.Size(133, 13);
            this.labelOutDir.TabIndex = 51;
            this.labelOutDir.Text = "Output Folder [.ftex/.ftexs]:";
            // 
            // labelPftxs
            // 
            this.labelPftxs.AutoSize = true;
            this.labelPftxs.Location = new System.Drawing.Point(12, 9);
            this.labelPftxs.Name = "labelPftxs";
            this.labelPftxs.Size = new System.Drawing.Size(144, 13);
            this.labelPftxs.TabIndex = 50;
            this.labelPftxs.Text = "Packed Textures File [.pftxs]:";
            // 
            // buttonPftxs
            // 
            this.buttonPftxs.Location = new System.Drawing.Point(463, 23);
            this.buttonPftxs.Name = "buttonPftxs";
            this.buttonPftxs.Size = new System.Drawing.Size(29, 23);
            this.buttonPftxs.TabIndex = 47;
            this.buttonPftxs.Text = "...";
            this.buttonPftxs.UseVisualStyleBackColor = true;
            this.buttonPftxs.Click += new System.EventHandler(this.buttonPftxs_Click);
            // 
            // buttonOutDir
            // 
            this.buttonOutDir.Location = new System.Drawing.Point(463, 72);
            this.buttonOutDir.Name = "buttonOutDir";
            this.buttonOutDir.Size = new System.Drawing.Size(29, 23);
            this.buttonOutDir.TabIndex = 49;
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
            this.textOutDir.TabIndex = 48;
            this.textOutDir.TextChanged += new System.EventHandler(this.textOutDir_TextChanged);
            // 
            // textPftxs
            // 
            this.textPftxs.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textPftxs.Enabled = false;
            this.textPftxs.Location = new System.Drawing.Point(12, 25);
            this.textPftxs.Name = "textPftxs";
            this.textPftxs.ReadOnly = true;
            this.textPftxs.Size = new System.Drawing.Size(445, 20);
            this.textPftxs.TabIndex = 46;
            this.textPftxs.TextChanged += new System.EventHandler(this.textPftxs_TextChanged);
            // 
            // buttonAggregate
            // 
            this.buttonAggregate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAggregate.Location = new System.Drawing.Point(345, 168);
            this.buttonAggregate.Name = "buttonAggregate";
            this.buttonAggregate.Size = new System.Drawing.Size(147, 33);
            this.buttonAggregate.TabIndex = 45;
            this.buttonAggregate.Text = "Aggregate Textures";
            this.buttonAggregate.UseVisualStyleBackColor = true;
            this.buttonAggregate.Click += new System.EventHandler(this.buttonAggregate_Click);
            // 
            // buttonArchiveDir
            // 
            this.buttonArchiveDir.Location = new System.Drawing.Point(345, 115);
            this.buttonArchiveDir.Name = "buttonArchiveDir";
            this.buttonArchiveDir.Size = new System.Drawing.Size(147, 23);
            this.buttonArchiveDir.TabIndex = 56;
            this.buttonArchiveDir.Text = "Set Archives Directory...";
            this.buttonArchiveDir.UseVisualStyleBackColor = true;
            this.buttonArchiveDir.Click += new System.EventHandler(this.buttonArchiveDir_Click);
            // 
            // textArchiveDir
            // 
            this.textArchiveDir.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textArchiveDir.Enabled = false;
            this.textArchiveDir.Location = new System.Drawing.Point(12, 116);
            this.textArchiveDir.Name = "textArchiveDir";
            this.textArchiveDir.ReadOnly = true;
            this.textArchiveDir.Size = new System.Drawing.Size(327, 20);
            this.textArchiveDir.TabIndex = 55;
            this.textArchiveDir.TextChanged += new System.EventHandler(this.textArchiveDir_TextChanged);
            // 
            // textInFiles
            // 
            this.textInFiles.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textInFiles.Enabled = false;
            this.textInFiles.Location = new System.Drawing.Point(12, 25);
            this.textInFiles.Name = "textInFiles";
            this.textInFiles.ReadOnly = true;
            this.textInFiles.Size = new System.Drawing.Size(445, 20);
            this.textInFiles.TabIndex = 46;
            // 
            // checkDirStruc
            // 
            this.checkDirStruc.AutoSize = true;
            this.checkDirStruc.Location = new System.Drawing.Point(12, 161);
            this.checkDirStruc.Name = "checkDirStruc";
            this.checkDirStruc.Size = new System.Drawing.Size(152, 17);
            this.checkDirStruc.TabIndex = 57;
            this.checkDirStruc.Text = "Include Directory Structure";
            this.checkDirStruc.UseVisualStyleBackColor = true;
            this.checkDirStruc.CheckedChanged += new System.EventHandler(this.checkDirStruc_CheckedChanged);
            // 
            // FormAggregator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 213);
            this.Controls.Add(this.checkDirStruc);
            this.Controls.Add(this.buttonArchiveDir);
            this.Controls.Add(this.textArchiveDir);
            this.Controls.Add(this.checkConvertDDS);
            this.Controls.Add(this.labelOutDir);
            this.Controls.Add(this.labelPftxs);
            this.Controls.Add(this.buttonPftxs);
            this.Controls.Add(this.buttonOutDir);
            this.Controls.Add(this.textOutDir);
            this.Controls.Add(this.textPftxs);
            this.Controls.Add(this.buttonAggregate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAggregator";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Texture Aggregator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkConvertDDS;
        private System.Windows.Forms.Label labelOutDir;
        private System.Windows.Forms.Label labelPftxs;
        private System.Windows.Forms.Button buttonPftxs;
        private System.Windows.Forms.Button buttonOutDir;
        private System.Windows.Forms.TextBox textOutDir;
        private System.Windows.Forms.TextBox textPftxs;
        private System.Windows.Forms.Button buttonAggregate;
        private System.Windows.Forms.Button buttonArchiveDir;
        private System.Windows.Forms.TextBox textArchiveDir;
        private System.Windows.Forms.TextBox textInFiles;
        private System.Windows.Forms.CheckBox checkDirStruc;
    }
}