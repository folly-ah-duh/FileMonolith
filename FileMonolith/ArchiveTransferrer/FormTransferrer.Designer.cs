namespace ArchiveTransferrer
{
    partial class FormTransferrer
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
            this.labelTPPEXE = new System.Windows.Forms.Label();
            this.labelGZEXE = new System.Windows.Forms.Label();
            this.buttonGZEXE = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonTPPEXE = new System.Windows.Forms.Button();
            this.textTPPEXE = new System.Windows.Forms.TextBox();
            this.textGZEXE = new System.Windows.Forms.TextBox();
            this.labelGZFOUND = new System.Windows.Forms.Label();
            this.labelMGOFOUND = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTPPEXE
            // 
            this.labelTPPEXE.AutoSize = true;
            this.labelTPPEXE.Location = new System.Drawing.Point(12, 77);
            this.labelTPPEXE.Name = "labelTPPEXE";
            this.labelTPPEXE.Size = new System.Drawing.Size(115, 13);
            this.labelTPPEXE.TabIndex = 16;
            this.labelTPPEXE.Text = "\'mgsvtpp.exe\' Location";
            // 
            // labelGZEXE
            // 
            this.labelGZEXE.AutoSize = true;
            this.labelGZEXE.Location = new System.Drawing.Point(12, 11);
            this.labelGZEXE.Name = "labelGZEXE";
            this.labelGZEXE.Size = new System.Drawing.Size(163, 13);
            this.labelGZEXE.TabIndex = 15;
            this.labelGZEXE.Text = "\'MgsGroundZeroes.exe\' Location";
            // 
            // buttonGZEXE
            // 
            this.buttonGZEXE.Location = new System.Drawing.Point(463, 25);
            this.buttonGZEXE.Name = "buttonGZEXE";
            this.buttonGZEXE.Size = new System.Drawing.Size(29, 23);
            this.buttonGZEXE.TabIndex = 11;
            this.buttonGZEXE.Text = "...";
            this.buttonGZEXE.UseVisualStyleBackColor = true;
            this.buttonGZEXE.Click += new System.EventHandler(this.buttonGZEXE_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(365, 151);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(127, 33);
            this.buttonStart.TabIndex = 14;
            this.buttonStart.Text = "Transfer Archives";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonTPPEXE
            // 
            this.buttonTPPEXE.Location = new System.Drawing.Point(463, 91);
            this.buttonTPPEXE.Name = "buttonTPPEXE";
            this.buttonTPPEXE.Size = new System.Drawing.Size(29, 23);
            this.buttonTPPEXE.TabIndex = 13;
            this.buttonTPPEXE.Text = "...";
            this.buttonTPPEXE.UseVisualStyleBackColor = true;
            this.buttonTPPEXE.Click += new System.EventHandler(this.buttonTPPEXE_Click);
            // 
            // textTPPEXE
            // 
            this.textTPPEXE.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textTPPEXE.Enabled = false;
            this.textTPPEXE.Location = new System.Drawing.Point(12, 93);
            this.textTPPEXE.Name = "textTPPEXE";
            this.textTPPEXE.ReadOnly = true;
            this.textTPPEXE.Size = new System.Drawing.Size(445, 20);
            this.textTPPEXE.TabIndex = 12;
            // 
            // textGZEXE
            // 
            this.textGZEXE.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textGZEXE.Enabled = false;
            this.textGZEXE.Location = new System.Drawing.Point(12, 27);
            this.textGZEXE.Name = "textGZEXE";
            this.textGZEXE.ReadOnly = true;
            this.textGZEXE.Size = new System.Drawing.Size(445, 20);
            this.textGZEXE.TabIndex = 10;
            // 
            // labelGZFOUND
            // 
            this.labelGZFOUND.AutoSize = true;
            this.labelGZFOUND.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGZFOUND.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelGZFOUND.Location = new System.Drawing.Point(12, 50);
            this.labelGZFOUND.Name = "labelGZFOUND";
            this.labelGZFOUND.Size = new System.Drawing.Size(0, 13);
            this.labelGZFOUND.TabIndex = 17;
            // 
            // labelMGOFOUND
            // 
            this.labelMGOFOUND.AutoSize = true;
            this.labelMGOFOUND.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMGOFOUND.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelMGOFOUND.Location = new System.Drawing.Point(12, 116);
            this.labelMGOFOUND.Name = "labelMGOFOUND";
            this.labelMGOFOUND.Size = new System.Drawing.Size(0, 13);
            this.labelMGOFOUND.TabIndex = 18;
            // 
            // FormTransferrer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 196);
            this.Controls.Add(this.labelMGOFOUND);
            this.Controls.Add(this.labelGZFOUND);
            this.Controls.Add(this.labelTPPEXE);
            this.Controls.Add(this.labelGZEXE);
            this.Controls.Add(this.buttonGZEXE);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonTPPEXE);
            this.Controls.Add(this.textTPPEXE);
            this.Controls.Add(this.textGZEXE);
            this.Name = "FormTransferrer";
            this.ShowIcon = false;
            this.Text = "File Transferrer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTPPEXE;
        private System.Windows.Forms.Label labelGZEXE;
        private System.Windows.Forms.Button buttonGZEXE;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonTPPEXE;
        private System.Windows.Forms.TextBox textTPPEXE;
        private System.Windows.Forms.TextBox textGZEXE;
        private System.Windows.Forms.Label labelGZFOUND;
        private System.Windows.Forms.Label labelMGOFOUND;
    }
}

