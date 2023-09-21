﻿namespace SearchFilesUtility
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new System.Windows.Forms.Label();
            txtDirectoryName = new System.Windows.Forms.TextBox();
            btnSelectDirectory = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            txtFileName = new System.Windows.Forms.TextBox();
            btnSelectFile = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            txtSearchResults = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            txtSearchString = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();
            btnCopy = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            lblFilesSearched = new System.Windows.Forms.Label();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 50);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(93, 15);
            label1.TabIndex = 0;
            label1.Text = "Search Directory";
            // 
            // txtDirectoryName
            // 
            txtDirectoryName.Location = new System.Drawing.Point(116, 48);
            txtDirectoryName.Margin = new System.Windows.Forms.Padding(2);
            txtDirectoryName.Name = "txtDirectoryName";
            txtDirectoryName.Size = new System.Drawing.Size(948, 23);
            txtDirectoryName.TabIndex = 1;
            // 
            // btnSelectDirectory
            // 
            btnSelectDirectory.Location = new System.Drawing.Point(1070, 46);
            btnSelectDirectory.Margin = new System.Windows.Forms.Padding(2);
            btnSelectDirectory.Name = "btnSelectDirectory";
            btnSelectDirectory.Size = new System.Drawing.Size(36, 22);
            btnSelectDirectory.TabIndex = 2;
            btnSelectDirectory.Text = "...";
            btnSelectDirectory.UseVisualStyleBackColor = true;
            btnSelectDirectory.Click += btnSelectDirectory_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 82);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(20, 15);
            label2.TabIndex = 3;
            label2.Text = "Or";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(11, 112);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(63, 15);
            label3.TabIndex = 4;
            label3.Text = "Search File";
            // 
            // txtFileName
            // 
            txtFileName.Location = new System.Drawing.Point(116, 109);
            txtFileName.Margin = new System.Windows.Forms.Padding(2);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new System.Drawing.Size(948, 23);
            txtFileName.TabIndex = 5;
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new System.Drawing.Point(1070, 109);
            btnSelectFile.Margin = new System.Windows.Forms.Padding(2);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new System.Drawing.Size(35, 22);
            btnSelectFile.TabIndex = 6;
            btnSelectFile.Text = "...";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.PaleGreen;
            btnSearch.Location = new System.Drawing.Point(1018, 136);
            btnSearch.Margin = new System.Windows.Forms.Padding(2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(88, 57);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchResults
            // 
            txtSearchResults.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtSearchResults.Location = new System.Drawing.Point(14, 199);
            txtSearchResults.Margin = new System.Windows.Forms.Padding(2);
            txtSearchResults.Multiline = true;
            txtSearchResults.Name = "txtSearchResults";
            txtSearchResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtSearchResults.Size = new System.Drawing.Size(1091, 523);
            txtSearchResults.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(11, 157);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(76, 15);
            label4.TabIndex = 9;
            label4.Text = "Search String";
            // 
            // txtSearchString
            // 
            txtSearchString.Location = new System.Drawing.Point(116, 153);
            txtSearchString.Margin = new System.Windows.Forms.Padding(2);
            txtSearchString.Name = "txtSearchString";
            txtSearchString.Size = new System.Drawing.Size(868, 23);
            txtSearchString.TabIndex = 10;
            txtSearchString.KeyDown += txtSearchString_KeyDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(11, 733);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(47, 13);
            label5.TabIndex = 11;
            label5.Text = "Status:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(116, 733);
            lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(52, 15);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "lblStatus";
            // 
            // btnCopy
            // 
            btnCopy.Location = new System.Drawing.Point(1039, 728);
            btnCopy.Margin = new System.Windows.Forms.Padding(2);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new System.Drawing.Size(65, 23);
            btnCopy.TabIndex = 13;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(11, 756);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(89, 15);
            label6.TabIndex = 14;
            label6.Text = "Files Searched:";
            // 
            // lblFilesSearched
            // 
            lblFilesSearched.AutoSize = true;
            lblFilesSearched.Location = new System.Drawing.Point(116, 756);
            lblFilesSearched.Name = "lblFilesSearched";
            lblFilesSearched.Size = new System.Drawing.Size(91, 15);
            lblFilesSearched.TabIndex = 15;
            lblFilesSearched.Text = "lblFilesSearched";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1127, 24);
            menuStrip1.TabIndex = 16;
            menuStrip1.Text = "menuStrip1";            
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1127, 795);
            Controls.Add(lblFilesSearched);
            Controls.Add(label6);
            Controls.Add(btnCopy);
            Controls.Add(lblStatus);
            Controls.Add(label5);
            Controls.Add(txtSearchString);
            Controls.Add(label4);
            Controls.Add(txtSearchResults);
            Controls.Add(btnSearch);
            Controls.Add(btnSelectFile);
            Controls.Add(txtFileName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnSelectDirectory);
            Controls.Add(txtDirectoryName);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(2);
            MaximizeBox = false;
            MinimumSize = new System.Drawing.Size(1143, 834);
            Name = "Form1";
            Text = "Search Files Utility";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirectoryName;
        private System.Windows.Forms.Button btnSelectDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchResults;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearchString;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFilesSearched;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

