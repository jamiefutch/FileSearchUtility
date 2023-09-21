using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchFilesUtility.Controllers;

namespace SearchFilesUtility
{
    public partial class Form1 : Form
    {

        private const int formMinWidth = 1131;
        private const int formMinHeight = 783;
        private int formLastHeight;
        private int formLastWidth;

        public Form1()
        {
            InitializeComponent();
            this.Resize += new EventHandler(this.Form1_Resize);
            formLastHeight = formMinHeight;
            formLastWidth = formMinWidth;
        }

        private void btnSelectDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                Console.WriteLine(fbd.SelectedPath);
                txtDirectoryName.Text = fbd.SelectedPath;
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            DialogResult result = fd.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFileName.Text = fd.FileName;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void DoSearch()
        {
            disableButtons();
            txtSearchResults.Text = "";
            setStatus("Searching...");

            Stopwatch stopwatch = new Stopwatch();
            const string cr = "\r\n";
            //List<Controllers.SearchResult> results = new List<Controllers.SearchResult>();
            ResultsSet results = new ResultsSet();
            stopwatch.Start();
            if (txtDirectoryName.Text.Length > 0 && txtSearchString.Text.Length > 0)
            {
                results = SearchController.SearchFilesInDirectory(txtDirectoryName.Text, txtSearchString.Text, this);
            }
            stopwatch.Stop();


            if (!results.Complete)
            {
                setStatus("Results set too long.  Results truncated.");
            }
            txtSearchResults.Text = $"line #\tFilename\r\n{results.SearchResults}";

            setStatus("Done. Search Time: " + (stopwatch.ElapsedMilliseconds / 1000).ToString());
            enableButtons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            lblFilesSearched.Text = "";
            this.AcceptButton = btnSearch;
            formLastHeight = this.Height;
            formLastWidth = this.Width;
        }

        //TODO: working on this
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            // cache new diminsions
            if (this.Height > formMinHeight)
            {
                int diff = (this.Height - formLastHeight);
                btnCopy.Top = btnCopy.Top + diff;

                label6.Top = label6.Top + diff;
                lblStatus.Top = lblStatus.Top + diff;
                label5.Top = label5.Top + diff;
                lblFilesSearched.Top = lblFilesSearched.Top + diff;
                txtSearchResults.Height = txtSearchResults.Height + diff;

                formLastHeight = this.Height;
            }
            else
            {
                this.Height = formLastHeight;
            }

            if (this.Height < formLastHeight)
            {
                int diff = (formLastHeight - this.Height);
                //btnCopy.Top = btnCopy.Top - (formLastHeight - this.Height) + btnCopy.Height;
                btnCopy.Top = btnCopy.Top - diff;

                label6.Top = label6.Top - diff;
                lblStatus.Top = lblStatus.Top - diff;
                label5.Top = label5.Top - diff;
                lblFilesSearched.Top = lblFilesSearched.Top - diff;
                txtSearchResults.Height = txtSearchResults.Height - diff;

                formLastHeight = this.Height;
            }



            if (this.Width > formMinWidth)
            {
                int diff = (this.Width - formLastWidth);
                btnCopy.Left = btnCopy.Left + diff;
                txtSearchResults.Width = txtSearchResults.Width + diff;
                btnSelectDirectory.Left = btnSelectDirectory.Left + diff;
                btnSelectFile.Left = btnSelectFile.Left + diff;
                txtDirectoryName.Width = txtDirectoryName.Width + diff;
                txtFileName.Width = txtFileName.Width + diff;
                btnSearch.Left = btnSearch.Left + diff;
                txtSearchString.Width = txtSearchString.Width + diff;

                formLastWidth = this.Width;
            }
            else
            {
                this.Width = formLastWidth;
            }


            if (this.Width < formMinWidth)
            {
                int diff = (formLastWidth - this.Width);
                txtSearchResults.Width = txtSearchResults.Width - diff;
                btnSelectDirectory.Left = btnSelectDirectory.Left - diff;
                btnSelectFile.Left = btnSelectFile.Left - diff;
                txtDirectoryName.Width = txtDirectoryName.Width - diff;
                txtFileName.Width = txtFileName.Width - diff;
                btnSearch.Width = btnSearch.Width - diff;
                txtSearchString.Width = txtSearchString.Width - diff;

                formLastWidth = this.Width;
            }





        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtSearchResults.Text.Length > 0)
            {
                txtSearchResults.SelectAll();
                Clipboard.SetText(txtSearchResults.Text);
                txtSearchResults.SelectionStart = 0;
                txtSearchResults.SelectionLength = txtSearchResults.Text.Length;
                txtSearchResults.Select(0, txtSearchResults.Text.Length - 1);
            }
        }

        private void enableButtons()
        {
            btnSearch.Enabled = true;
            btnSelectDirectory.Enabled = true;
            btnSelectFile.Enabled = true;
            btnCopy.Enabled = true;
        }

        private void disableButtons()
        {
            btnSearch.Enabled = false;
            btnSelectDirectory.Enabled = false;
            btnSelectFile.Enabled = false;
            btnCopy.Enabled = false;
        }

        public void setFilesSearchedCount(int count, int total)
        {
            lblFilesSearched.Text = $"{count} / {total}";
            lblFilesSearched.Refresh();
        }

        public void setStatus(string status)
        {
            lblStatus.Text = status;
            lblStatus.Refresh();
        }


        private void txtSearchString_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearchString.Text.Length > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Console.Write(txtSearchString.Text);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    DoSearch();
                }

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
