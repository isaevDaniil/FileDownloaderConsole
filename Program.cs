using FileDownloaderLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileDownloaderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь сохранения: ");
            var pathToSave = Console.ReadLine();          
            var filesUrl = new List<string>(80);

            var downloader = new FileDownloader();
            downloader.OnDownloaded += DisplayMessage;
            downloader.OnFailed += DisplayError;
            using (var sr = new StreamReader("FilesToDownload.txt"))
            {
                while (!sr.EndOfStream)
                {
                    filesUrl.Add(sr.ReadLine());
                }              
            }
            for (int i = 0; i < filesUrl.Count; i++)
            {
                downloader.AddFileToDownloadingQueue(i.ToString(), filesUrl[i], pathToSave);
            }
            Console.ReadLine();
        }
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        public static void DisplayError(string message,Exception e)
        {
            Console.WriteLine(message+e.Message);
        }
    }
}
