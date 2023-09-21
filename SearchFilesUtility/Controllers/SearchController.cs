using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchFilesUtility.Controllers
{
    public static class SearchController
    {
        private static List<string> _fileList;
        private static List<SearchResult> _searchResultList;
        private static Form1 _form1;
        private static List<string> _excludeList;

        public static ResultsSet SearchFilesInDirectory(string DirectoryPath,
            string SearchString,
            Form1 form1)
        {
            _excludeList =  BuildExcludeList();
            int filesSearchedCount = 0;
            _form1 = form1;
            _fileList = new List<string>();

            _form1.setStatus("Building File List...");
            System.IO.DirectoryInfo di = new DirectoryInfo(DirectoryPath);
            WalkDirectoryTree(di);

            _form1.setStatus("Searching Files...");
            StringBuilder s = new StringBuilder();
            double cap = s.MaxCapacity;
            bool SearchComplete = true;
            FileSearchController fsc = new FileSearchController();
            
            int fileCount = _fileList.Count;
            foreach (string p in _fileList)
            {                   
                try
                {
                    if (!IsFileExcluded(p))
                    {
                        var tooLargeToScan = false;
                        var found = false;
                        FileInfo fi = new FileInfo(p);
                        if(fi.Length > 200 && fi.Length < 10000)
                        {
                            var f = File.ReadAllText(p);
                            Application.DoEvents();
                            var trie = new Trie();
                            trie.Add(SearchString);
                            trie.Build();
                            found = trie.Find(f).Any();                            
                        }
                        else
                        { tooLargeToScan=true;}

                        if (tooLargeToScan || found == true)
                        {
                            s.Append(fsc.SearchFile4(p, SearchStringToArray(SearchString)));
                        }
                        if ((double)s.Capacity / cap >= .4)
                        { 
                            SearchComplete = false;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
                filesSearchedCount++;
                if (filesSearchedCount % 100 == 0)
                {
                    _form1.setFilesSearchedCount(filesSearchedCount, fileCount);
                }
            };
            _form1.setFilesSearchedCount(filesSearchedCount, fileCount);
            ResultsSet rs = new ResultsSet
            {
                Complete = SearchComplete,
                SearchResults = s.ToString()
            };

            return rs;
        }


        public static List<SearchResult> SearchFile(string FilePath, string SearchString)
        {
            List<SearchResult> srlist = new List<SearchResult>();
            try
            {
                Int32 LineCount = 1;
                foreach (string line in File.ReadLines(FilePath))
                {
                    Application.DoEvents();
                    Int32 index = 0;
                    index = line.IndexOf(SearchString, StringComparison.CurrentCultureIgnoreCase);
                    if (index >= 0)
                    {
                        SearchResult sr = new SearchResult();
                        sr.FileName = FilePath;
                        sr.LineNumber = LineCount;
                        srlist.Add(sr);
                    }
                    LineCount++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return srlist;
        }

        private static string[] SearchStringToArray(string searchString)
        {

            return new string[] { searchString };
        }

        static void WalkDirectoryTree(System.IO.DirectoryInfo root)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // do nothing, ignore the file    
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
#if DEBUG
                Console.WriteLine(e.Message);
#endif
            }

            catch (System.IO.PathTooLongException e)
            {
#if DEBUG
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
#endif
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {                                                            
                    try
                    {
                        Application.DoEvents();
                        _fileList.Add(fi.FullName);
                    }
                    catch (Exception ex)
                    {
#if DEBUG
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
#endif
                    }
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(dirInfo);
                }
            }
        }

        public static List<string> BuildExcludeList()
        {
            List<string> list = new List<string>();
            list.Add(".git");
            list.Add(".mdf");
            list.Add(".exe");
            list.Add(".dll");
            list.Add(".zip");
            list.Add(".rar");
            list.Add(".bmp");
            list.Add(".jpg");
            list.Add(".jpeg");
            list.Add(".dcm");
            list.Add(".so");
            list.Add(".pdb");
            return list;
        }

        public static bool IsFileExcluded(string fileName)
        {
            bool retval = false;
            foreach(string s in _excludeList)
            {
                if(fileName.Contains(s))
                {
                    retval = true;
                    break;
                }
            }
            return retval;
        }

    }        

    public struct SearchResult {
        public string FileName { get; set; }
        public int LineNumber { get; set; } 
    }
    
    public struct ResultsSet
    {
        public string SearchResults { get; set; }
        public bool Complete { get; set; }
    }
}
