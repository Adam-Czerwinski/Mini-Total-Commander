namespace TotalCommander
{
    partial class UCPane
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxDrives = new System.Windows.Forms.ComboBox();
            this.listBoxDirectoriesAndFiles = new System.Windows.Forms.ListBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.FormattingEnabled = true;
            this.comboBoxDrives.Location = new System.Drawing.Point(4, 27);
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(53, 21);
            this.comboBoxDrives.TabIndex = 0;
            this.comboBoxDrives.SelectedIndexChanged += new System.EventHandler(this.comboBoxDrives_SelectedIndexChanged);
            this.comboBoxDrives.Click += new System.EventHandler(this.comboBoxDrives_Click);
            // 
            // listBoxDirectoriesAndFiles
            // 
            this.listBoxDirectoriesAndFiles.FormattingEnabled = true;
            this.listBoxDirectoriesAndFiles.Location = new System.Drawing.Point(4, 54);
            this.listBoxDirectoriesAndFiles.Name = "listBoxDirectoriesAndFiles";
            this.listBoxDirectoriesAndFiles.Size = new System.Drawing.Size(293, 290);
            this.listBoxDirectoriesAndFiles.TabIndex = 1;
            this.listBoxDirectoriesAndFiles.DoubleClick += new System.EventHandler(this.listBoxDirectoriesAndFiles_DoubleClick);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(4, 3);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxPath.Size = new System.Drawing.Size(293, 20);
            this.textBoxPath.TabIndex = 2;
            this.textBoxPath.TextChanged += new System.EventHandler(this.textBoxPath_TextChanged);
            // 
            // buttonBack
            // 
            this.buttonBack.Enabled = false;
            this.buttonBack.Location = new System.Drawing.Point(254, 29);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(43, 23);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.Text = "back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // UCLeftPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.listBoxDirectoriesAndFiles);
            this.Controls.Add(this.comboBoxDrives);
            this.Name = "UCLeftPane";
            this.Size = new System.Drawing.Size(300, 350);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDrives;
        private System.Windows.Forms.ListBox listBoxDirectoriesAndFiles;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonBack;
    }
}
