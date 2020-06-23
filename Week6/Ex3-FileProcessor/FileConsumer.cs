using System;
using System.IO;
using System.Net;
using System.Threading;

namespace FileProcessor
{
    internal class FileConsumer
    {
        private  CountdownEvent countdownEvent;
        private  CancellationToken token;
        private  SemaphoreSlim semafore;
        private int maxThreads = 4;
        public FileConsumer(CountdownEvent countdownEvent, CancellationToken token)
        {
            semafore = new SemaphoreSlim(maxThreads);

            this.countdownEvent = countdownEvent;
            this.token = token;
        }

        internal void consumeFiles()
        {
            //read until the token is cancelled
            while(!token.IsCancellationRequested)
            {
                lock(FileStorage.FilesQueque)
                {
                    //we have files to consume ?
                    if(FileStorage.FilesQueque.Count > 0)
                    {
                        semafore.Wait();
                        var path = FileStorage.FilesQueque.Dequeue();

                        var fileName = Path.GetFileName(path);
                        var fileContent = File.ReadAllText(path);
                        //var fileSize = File.GetAttributes(fileSize);
                        
                        //process file
                        FileStorage.ProcessedFiles.TryAdd(fileName, fileContent);
                        
                        //decrease
                        this.countdownEvent.Signal();

                        semafore.Release();
                    }
                }
            }
        }
    }
}