using System;
using System.IO;

namespace FileProcessor
{
	public class FilePublisher
	{
		private FileSystemWatcher watcher;
		public FilePublisher()
		{
			watcher = new FileSystemWatcher();
		}

		public void Monitor()
        {
			watcher.Path = @"d:\dotnet\dotnet\Resources";
			watcher.Created += onCreated;
			watcher.EnableRaisingEvents = true;


        }

		public void onCreated(Object source, FileSystemEventArgs e) => FileStorage.FilesQueque.Enqueue(e.FullPath);
	
	}


}
