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
        public Form1()
        {
            InitializeComponent();
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
            txtSearchResults.Text = "";
            lblStatus.Text = "Searching...";

            Stopwatch stopwatch = new Stopwatch();
            const string cr = "\r\n";
            List<Controllers.SearchResult> results = new List<Controllers.SearchResult>();
            stopwatch.Start();
            if (txtDirectoryName.Text.Length > 0 && txtSearchString.Text.Length > 0)
            {
                results = SearchController.SearchFilesInDirectory(txtDirectoryName.Text,txtSearchString.Text);
            }
            else if (txtFileName.Text.Length > 0 && txtSearchString.Text.Length > 0)
            {
                results = SearchController.SearchFile(txtFileName.Text,txtSearchString.Text);
            }
            stopwatch.Stop();


            if (results.Count > 0)
            {
                StringBuilder s = new StringBuilder();
                foreach (SearchResult result in results)
                {
                    s.Append(result.FileName + "\t Line: " + result.LineNumber + cr);
                    Application.DoEvents();
                }
                txtSearchResults.Text = s.ToString();
            }

            lblStatus.Text = "Done. Search Time: " + (stopwatch.ElapsedMilliseconds / 1000).ToString() ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSearchResults.Text.Length > 0)
            {
                txtSearchResults.SelectAll();
                Clipboard.SetText(txtSearchResults.Text);
                txtSearchResults.SelectionStart = 0;
                txtSearchResults.SelectionLength = txtSearchResults.Text.Length;
                txtSearchResults.Select(0,txtSearchResults.Text.Length-1);
            }
        }
    }
}
