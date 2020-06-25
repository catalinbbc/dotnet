using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace FileProcessor
{
    class ProgramAwait
    {

        private static CancellationTokenSource tokenSource = new CancellationTokenSource();
        private static CancellationToken token = tokenSource.Token;

        private static int fileNumberExpected = 10;
        private static CountdownEvent countdownEvent;
        private SemaphoreSlim semafore;
        private int maxThreads = 4;

        public static ConcurrentDictionary<string, string> ProcessedFiles = new ConcurrentDictionary<string, string>();

        static async Task Main(string[] args)
        {
            
            Console.WriteLine("W6 - Ex3 - Files Processor with Await");

            countdownEvent = new CountdownEvent(fileNumberExpected);
            semafore = new SemaphoreSlim(maxThreads);

            await FileMonitorAsync();


            //display the processed files
            foreach ((string file, string fileContent) in ProcessedFiles)
            {
                Console.WriteLine("file {0}, content:{1}", file, fileContent);

            }

        }


        private static async Task FileMonitorAsync()
        {
            watcher.Path = @"d:\dotnet\dotnet\Resources";
            watcher.Created += onCreated;
            watcher.EnableRaisingEvents = true;
        }

        public void onCreated(Object source, FileSystemEventArgs e)
        {
            FileStorage.FilesQueque.Enqueue(e.FullPath);
            return Task.Run(() => this.consumeFilesAsync());
        }

        private static async Task consumeFilesAsync()
        {
            //read until the token is cancelled
            while (!token.IsCancellationRequested)
            {
                lock (FilesQueque)
                {
                    //we have files to consume ?
                    if (FilesQueque.Count > 0)
                    {
                        semafore.Wait();
                        var path = FilesQueque.Dequeue();

                        var fileName = Path.GetFileName(path);
                        var fileContent = File.ReadAllText(path);
                        //var fileSize = File.GetAttributes(fileSize);

                        //process file
                        ProcessedFiles.TryAdd(fileName, fileContent);

                        //decrease
                        this.countdownEvent.Signal();
                        semafore.Release();
                    }
                }
            }
        }
    }
}
