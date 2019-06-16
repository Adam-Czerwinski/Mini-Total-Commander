namespace TotalCommander
{
    partial class Form
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
            this.buttonCopy = new System.Windows.Forms.Button();
            this.labelCopyInformation = new System.Windows.Forms.Label();
            this.leftPane = new TotalCommander.UCPane();
            this.rightPane = new TotalCommander.UCPane();
            this.SuspendLayout();
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(364, 235);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 2;
            this.buttonCopy.Text = "Copy>>";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // labelCopyInformation
            // 
            this.labelCopyInformation.AutoSize = true;
            this.labelCopyInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCopyInformation.Location = new System.Drawing.Point(215, 391);
            this.labelCopyInformation.Name = "labelCopyInformation";
            this.labelCopyInformation.Size = new System.Drawing.Size(397, 80);
            this.labelCopyInformation.TabIndex = 3;
            this.labelCopyInformation.Text = "Uwaga! Kopiowanie odbywa się w następujący sposób:\r\nZ: ścieżka + zaznaczony eleme" +
    "nt\r\nDo: ścieżka \r\nKopiuje zawartość folderu, a nie folder i jego zawartość!";
            // 
            // leftPane
            // 
            this.leftPane.CurrentPath = "";
            this.leftPane.loadDirectoriesAndFiles = null;
            this.leftPane.loadDrives = null;
            this.leftPane.Location = new System.Drawing.Point(12, 30);
            this.leftPane.Name = "leftPane";
            this.leftPane.Size = new System.Drawing.Size(300, 350);
            this.leftPane.TabIndex = 0;
            this.leftPane.Enter += new System.EventHandler(this.leftPane_Enter);
            // 
            // rightPane
            // 
            this.rightPane.CurrentPath = "";
            this.rightPane.loadDirectoriesAndFiles = null;
            this.rightPane.loadDrives = null;
            this.rightPane.Location = new System.Drawing.Point(488, 30);
            this.rightPane.Name = "rightPane";
            this.rightPane.Size = new System.Drawing.Size(300, 350);
            this.rightPane.TabIndex = 4;
            this.rightPane.Enter += new System.EventHandler(this.rightPane_Enter);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.rightPane);
            this.Controls.Add(this.labelCopyInformation);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.leftPane);
            this.Name = "Form";
            this.Text = "Total Commander";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UCPane leftPane;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Label labelCopyInformation;
        private UCPane rightPane;
    }
}

