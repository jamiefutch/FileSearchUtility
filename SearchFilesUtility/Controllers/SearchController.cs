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

        public static List<SearchResult> SearchFilesInDirectory(string DirectoryPath, string SearchString)
        {

            _fileList = new List<string>();
            System.IO.DirectoryInfo di = new DirectoryInfo(DirectoryPath);
            WalkDirectoryTree(di);
            List<SearchResult> srlist = new List<SearchResult>();
            //foreach (string p in _fileList)
            FileSearchController fsc = new FileSearchController();
            foreach (string p in _fileList)
            {
                //Int32 LineCount = 1;
                try
                {
                    /**
                    foreach (string line in File.ReadLines(p))
                    {
                        Application.DoEvents();
                        Int32 index = 0;
                        index = line.IndexOf(SearchString, StringComparison.CurrentCultureIgnoreCase);
                        if (index >= 0)
                        {
                            SearchResult sr = new SearchResult();
                            sr.FileName = p;
                            sr.LineNumber = LineCount;
                            srlist.Add(sr);
                        }
                        LineCount++;
                    }
                    **/
                    /**
                    using (FileSearchController fsc = new FileSearchController())
                    {
                        List<SearchResult> resultlist = fsc.SearchFile(p, SearchString);
                        srlist.AddRange(resultlist);
                    }
                    **/
                    
                    //List<SearchResult> resultlist = fsc.SearchFile3(p, SearchString, ref srlist);
                    fsc.SearchFile3(p, SearchString, ref srlist);
                    //srlist.AddRange(resultlist);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
#if DEBUG
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
#endif
                }
            };

            /**
            List<SearchResult> srlist = new List<SearchResult>();
            try
            {
                FileInfo[] fi = new DirectoryInfo(DirectoryPath).GetFiles("*.*", SearchOption.AllDirectories);

                foreach (FileInfo f in fi)
                {
                    Int32 LineCount = 1;
                    foreach (string line in File.ReadLines(f.FullName))
                    {
                        Application.DoEvents();
                        Int32 index = 0;
                        index = line.IndexOf(SearchString, StringComparison.CurrentCultureIgnoreCase);
                        if (index >= 0)
                        {
                            SearchResult sr = new SearchResult();
                            sr.FileName = f.FullName;
                            sr.LineNumber = LineCount;
                            srlist.Add(sr);
                        }
                        LineCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            **/

            /**
            Parallel.ForEach(fi, (f) =>
            {
                Int32 LineCount = 1;
                foreach (string line in File.ReadLines(f.FullName))
                {
                    Application.DoEvents();
                    Int32 index = 0;
                    index = line.IndexOf(SearchString, StringComparison.CurrentCultureIgnoreCase);
                    if (index >= 0)
                    {
                        SearchResult sr = new SearchResult();
                        sr.FileName = f.FullName;
                        sr.LineNumber = LineCount;
                        srlist.Add(sr);
                    }
                    LineCount++;
                }                
                //resultlist.Add(currentFile);
            });
            **/


            
                return srlist;
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
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                //log.Add(e.Message);
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
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    //Console.WriteLine(fi.FullName);
                    try
                    {
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
    }

    public class SearchResult {
        public string FileName { get; set; }
        public Int32 LineNumber { get; set; } 
    }    
}
