namespace ArchiveUnpacker
{
    partial class FormUnpacker
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
            this.textArchives = new System.Windows.Forms.TextBox();
            this.buttonOutDir = new System.Windows.Forms.Button();
            this.textOutDir = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonArchives = new System.Windows.Forms.Button();
            this.labelArchives = new System.Windows.Forms.Label();
            this.labelOutDir = new System.Windows.Forms.Label();
            this.checkCondenseDir = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textArchives
            // 
            this.textArchives.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textArchives.Enabled = false;
            this.textArchives.Location = new System.Drawing.Point(12, 25);
            this.textArchives.Name = "textArchives";
            this.textArchives.ReadOnly = true;
            this.textArchives.Size = new System.Drawing.Size(445, 20);
            this.textArchives.TabIndex = 1;
            // 
            // buttonOutDir
            // 
            this.buttonOutDir.Location = new System.Drawing.Point(463, 72);
            this.buttonOutDir.Name = "buttonOutDir";
            this.buttonOutDir.Size = new System.Drawing.Size(29, 23);
            this.buttonOutDir.TabIndex = 4;
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
            this.textOutDir.TabIndex = 3;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(420, 117);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(72, 33);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Unpack";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonArchives
            // 
            this.buttonArchives.Location = new System.Drawing.Point(463, 23);
            this.buttonArchives.Name = "buttonArchives";
            this.buttonArchives.Size = new System.Drawing.Size(29, 23);
            this.buttonArchives.TabIndex = 2;
            this.buttonArchives.Text = "...";
            this.buttonArchives.UseVisualStyleBackColor = true;
            this.buttonArchives.Click += new System.EventHandler(this.buttonArchives_Click);
            // 
            // labelArchives
            // 
            this.labelArchives.AutoSize = true;
            this.labelArchives.Location = new System.Drawing.Point(12, 9);
            this.labelArchives.Name = "labelArchives";
            this.labelArchives.Size = new System.Drawing.Size(51, 13);
            this.labelArchives.TabIndex = 7;
            this.labelArchives.Text = "Archives:";
            // 
            // labelOutDir
            // 
            this.labelOutDir.AutoSize = true;
            this.labelOutDir.Location = new System.Drawing.Point(12, 58);
            this.labelOutDir.Name = "labelOutDir";
            this.labelOutDir.Size = new System.Drawing.Size(74, 13);
            this.labelOutDir.TabIndex = 8;
            this.labelOutDir.Text = "Output Folder:";
            // 
            // checkCondenseDir
            // 
            this.checkCondenseDir.AutoSize = true;
            this.checkCondenseDir.Location = new System.Drawing.Point(12, 126);
            this.checkCondenseDir.Name = "checkCondenseDir";
            this.checkCondenseDir.Size = new System.Drawing.Size(354, 17);
            this.checkCondenseDir.TabIndex = 9;
            this.checkCondenseDir.Text = "Condensed Directory Structure [Required for Mass Texture Converter]";
            this.checkCondenseDir.UseVisualStyleBackColor = true;
            // 
            // FormUnpacker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 162);
            this.Controls.Add(this.checkCondenseDir);
            this.Controls.Add(this.labelOutDir);
            this.Controls.Add(this.labelArchives);
            this.Controls.Add(this.buttonArchives);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonOutDir);
            this.Controls.Add(this.textOutDir);
            this.Controls.Add(this.textArchives);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormUnpacker";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Archive Unpacker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textArchives;
        private System.Windows.Forms.Button buttonOutDir;
        private System.Windows.Forms.TextBox textOutDir;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonArchives;
        private System.Windows.Forms.Label labelArchives;
        private System.Windows.Forms.Label labelOutDir;
        private System.Windows.Forms.CheckBox checkCondenseDir;
    }
}

