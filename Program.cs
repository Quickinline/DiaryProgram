using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace DiraryProgram
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DataBase.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            DataBase.Dispose();
        }
    }

    public static class DataBase
    {
        private static string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Data.zip";
        private static string DirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Data";
        private static string LogPath = DirectoryPath + "\\Log.dat";
        
        public static void Start ()
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            if(!File.Exists(FilePath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            else
            {
                ZipFile.ExtractToDirectory(FilePath, DirectoryPath);
                File.Delete(FilePath);
            }
            Cursor.Current = cursor;
        }

        public static void Dispose ()
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            if (Directory.Exists(DirectoryPath))
            {
                ZipFile.CreateFromDirectory(DirectoryPath, FilePath);
                DeleteDirectory(DirectoryPath);
                
            }
            Cursor.Current = cursor;
        }

        private static void DeleteDirectory (string Path)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            DirectoryInfo directory = new DirectoryInfo(Path);
            foreach(DirectoryInfo di in  directory.GetDirectories())
            {
                foreach(FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                di.Delete();
            }
            foreach(FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            
            directory.Delete();
            Cursor.Current = cursor;
        }

        public static void SaveText (string text)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
             

            string path = DirectoryPath + "\\" + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            StreamWriter sw = new StreamWriter(path+ "\\" + DateTime.Now.ToLongDateString() + ".dat", false);
            
            sw.Write(text);
            sw.Flush();
            sw.Close();

            sw = new StreamWriter(LogPath, true);
            sw.WriteLine(DateTime.Now.ToShortTimeString() + text);
            sw.Flush();
            sw.Close();

            Cursor.Current = cursor;
        }
        public static void SaveText(string text, DateTime date)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            string path = DirectoryPath + "\\" + date.Month.ToString() + date.Year.ToString();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            StreamWriter sw = new StreamWriter(path + "\\" + date.ToLongDateString() + ".dat", true);
            sw.Write(text);
            sw.Flush();
            sw.Close();

            sw = new StreamWriter(LogPath, true);
            sw.WriteLine(date.ToShortTimeString() + text);
            sw.Flush();
            sw.Close();

            Cursor.Current = cursor;
        }
        public static string ReadText (DateTime date)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            string path = DirectoryPath + "\\" + date.Month.ToString() + date.Year.ToString();
            if(!Directory.Exists(path))
            {
                Cursor.Current = cursor;
                return string.Empty;
            }
            else
            {
                if (!File.Exists(path + "\\" + date.ToLongDateString() + ".dat"))
                {
                    Cursor.Current = cursor;
                    return string.Empty;
                }
                else
                {
                    StreamReader sr = new StreamReader(path + "\\" + date.ToLongDateString() + ".dat");
                    
                    string data = sr.ReadToEnd();
                    
                    sr.Close();
                    Cursor.Current = cursor;
                    return data;
                }
            }
            

        }

    }
}
