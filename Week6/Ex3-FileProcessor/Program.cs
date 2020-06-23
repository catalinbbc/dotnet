using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FileProcessor
{
    class Program
    {
        
        private static CancellationTokenSource tokenSource = new CancellationTokenSource();
        private static CancellationToken token = tokenSource.Token;

        private static int fileNumberExpected = 10;

        private static CountdownEvent countdownEvent;
       

        static void Main(string[] args)
        {
            Console.WriteLine("W6 - Ex3 - Files Processor");
            countdownEvent = new CountdownEvent(fileNumberExpected);

            var publisher = new FilePublisher();
            var consumer  = new FileConsumer(countdownEvent, token);
        
            Task watcherTask = Task.Factory.StartNew(() =>
            {
                //wait for new files
                publisher.Monitor();
            }, token);

            var consumeTask = Task.Factory.StartNew(() =>
            {
                consumer.consumeFiles();
            }, token) ;

            watcherTask.Wait();
            //stop

            tokenSource.Cancel();

            //display the processed files
            foreach ((string file, string fileContent) in FileStorage.ProcessedFiles)
            {
                Console.WriteLine("file {0}, content:{1}", file, fileContent);

            }

        }

    }
}
