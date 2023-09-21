using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchFilesUtility.Controllers
{
    /// <summary>
    /// Controller for Searching files
    /// </summary>
    class FileSearchController : IDisposable
    {

        
        public List<SearchResult> SearchFile(string FileName, string SearchString)
        {
            List<SearchResult> srlist = new List<SearchResult>();
            int LineCount = 0;

            try
            {
                foreach (string line in File.ReadLines(FileName))
                {
                    Application.DoEvents();
                    Int32 index = 0;
                    index = line.IndexOf(SearchString, StringComparison.CurrentCultureIgnoreCase);
                    if (index >= 0)
                    {
                        SearchResult sr = new SearchResult();
                        sr.FileName = FileName;
                        sr.LineNumber = LineCount;
                        srlist.Add(sr);
                    }
                    LineCount++;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return srlist;
        }
        
        
        public async Task<List<SearchResult>> SearchFile2(string FileName, string SearchString)
        {
            List<SearchResult> srlist = new List<SearchResult>();
            int LineCount = 0;

            try
            {
                foreach (string line in File.ReadLines(FileName))
                {
                    Application.DoEvents();
                    Int32 index = 0;
                    index = line.IndexOf(SearchString, StringComparison.CurrentCultureIgnoreCase);
                    if (index >= 0)
                    {
                        SearchResult sr = new SearchResult();
                        sr.FileName = FileName;
                        sr.LineNumber = LineCount;
                        srlist.Add(sr);
                    }
                    LineCount++;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return srlist;
        }

        //public List<SearchResult> SearchFile3(string FileName, string SearchString)
        public List<SearchResult> SearchFile3(string FileName, string[] SearchString)
        {               
            List<SearchResult> searchResults = new List<SearchResult>(100000);
            int LineCount = 0;            
            try
            {                
                foreach (string line in File.ReadLines(FileName))
                {
                    Application.DoEvents();
                    //bool found = line.Contains(SearchString, StringComparison.CurrentCultureIgnoreCase);                    
                    var trie = new Trie();
                    trie.Add(SearchString);
                    trie.Build();
                    var found = trie.Find(line).Any();
                    if (found)
                    {
                        SearchResult sr = new SearchResult();
                        sr.FileName = FileName;
                        sr.LineNumber = LineCount;
                        searchResults.Add(sr);
                    }
                    LineCount++;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            searchResults.TrimExcess();
            return searchResults;
        }

        public StringBuilder SearchFile4(string FileName, string[] SearchString)
        {               
            StringBuilder s = new StringBuilder();
            int LineCount = 0;
            try
            {
                foreach (string line in File.ReadLines(FileName))
                {
                    Application.DoEvents();                    
                    var trie = new Trie();
                    trie.Add(SearchString);
                    trie.Build();
                    var found = trie.Find(line).Any();
                    if (found)
                    {
                        s.Append(LineCount);
                        s.Append("\t");
                        s.Append(FileName);
                        s.Append("\r\n");
                    }
                    LineCount++;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return s;
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
