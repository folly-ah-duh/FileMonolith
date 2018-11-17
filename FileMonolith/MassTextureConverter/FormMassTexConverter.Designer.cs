namespace MassTextureConverter
{
    partial class FormMassTexConverter
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
            this.labelOutDir = new System.Windows.Forms.Label();
            this.labelInDir = new System.Windows.Forms.Label();
            this.buttonInDir = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonOutDir = new System.Windows.Forms.Button();
            this.textOutDir = new System.Windows.Forms.TextBox();
            this.textInDir = new System.Windows.Forms.TextBox();
            this.checkConvertSubfolders = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelOutDir
            // 
            this.labelOutDir.AutoSize = true;
            this.labelOutDir.Location = new System.Drawing.Point(12, 58);
            this.labelOutDir.Name = "labelOutDir";
            this.labelOutDir.Size = new System.Drawing.Size(103, 13);
            this.labelOutDir.TabIndex = 15;
            this.labelOutDir.Text = "Output Folder [.dds]:";
            // 
            // labelInDir
            // 
            this.labelInDir.AutoSize = true;
            this.labelInDir.Location = new System.Drawing.Point(12, 9);
            this.labelInDir.Name = "labelInDir";
            this.labelInDir.Size = new System.Drawing.Size(125, 13);
            this.labelInDir.TabIndex = 14;
            this.labelInDir.Text = "Input Folder [.ftex/.ftexs]:";
            // 
            // buttonInDir
            // 
            this.buttonInDir.Location = new System.Drawing.Point(463, 23);
            this.buttonInDir.Name = "buttonInDir";
            this.buttonInDir.Size = new System.Drawing.Size(29, 23);
            this.buttonInDir.TabIndex = 10;
            this.buttonInDir.Text = "...";
            this.buttonInDir.UseVisualStyleBackColor = true;
            this.buttonInDir.Click += new System.EventHandler(this.buttonInDir_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(420, 117);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(72, 33);
            this.buttonStart.TabIndex = 13;
            this.buttonStart.Text = "Convert";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonOutDir
            // 
            this.buttonOutDir.Location = new System.Drawing.Point(463, 72);
            this.buttonOutDir.Name = "buttonOutDir";
            this.buttonOutDir.Size = new System.Drawing.Size(29, 23);
            this.buttonOutDir.TabIndex = 12;
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
            this.textOutDir.TabIndex = 11;
            // 
            // textInDir
            // 
            this.textInDir.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textInDir.Enabled = false;
            this.textInDir.Location = new System.Drawing.Point(12, 25);
            this.textInDir.Name = "textInDir";
            this.textInDir.ReadOnly = true;
            this.textInDir.Size = new System.Drawing.Size(445, 20);
            this.textInDir.TabIndex = 9;
            // 
            // checkConvertSubfolders
            // 
            this.checkConvertSubfolders.AutoSize = true;
            this.checkConvertSubfolders.Location = new System.Drawing.Point(12, 126);
            this.checkConvertSubfolders.Name = "checkConvertSubfolders";
            this.checkConvertSubfolders.Size = new System.Drawing.Size(116, 17);
            this.checkConvertSubfolders.TabIndex = 16;
            this.checkConvertSubfolders.Text = "Convert Subfolders";
            this.checkConvertSubfolders.UseVisualStyleBackColor = true;
            // 
            // FormMassTexConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 162);
            this.Controls.Add(this.checkConvertSubfolders);
            this.Controls.Add(this.labelOutDir);
            this.Controls.Add(this.labelInDir);
            this.Controls.Add(this.buttonInDir);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonOutDir);
            this.Controls.Add(this.textOutDir);
            this.Controls.Add(this.textInDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMassTexConverter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mass Texture Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelOutDir;
        private System.Windows.Forms.Label labelInDir;
        private System.Windows.Forms.Button buttonInDir;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonOutDir;
        private System.Windows.Forms.TextBox textOutDir;
        private System.Windows.Forms.TextBox textInDir;
        private System.Windows.Forms.CheckBox checkConvertSubfolders;
    }
}

