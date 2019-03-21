using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public void SearchFile3(string FileName, string SearchString, ref List<SearchResult> SearchResults)
        {
            //List<SearchResult> srlist = new List<SearchResult>();
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
                        SearchResults.Add(sr);
                    }
                    LineCount++;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
