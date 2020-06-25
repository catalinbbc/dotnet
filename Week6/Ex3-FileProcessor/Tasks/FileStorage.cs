using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace FileProcessor
{
    internal class FileStorage
    {
        public static Queue<string> FilesQueque = new Queue<string>();
        public static ConcurrentDictionary<string, string> ProcessedFiles = new ConcurrentDictionary<string, string>();
    }
}