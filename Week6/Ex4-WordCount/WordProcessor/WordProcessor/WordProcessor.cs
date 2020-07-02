using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordProcessor
{
    class WordProcessor
    {

		private ConcurrentDictionary<long,string> theWords;
		private ConcurrentDictionary<string,string> nrWordsPerCateg;
		private static object _lock = new object();
		public string[] categs;

		static long wordIndex;


		public WordProcessor()
		{
			this.theWords = new ConcurrentDictionary<long, string>();
			this.nrWordsPerCateg = new ConcurrentDictionary<string, string>();

			this.categs = new string[4] { "xs", "s", "m", "l" };
          

		}

		
		public async Task ReadFileAsync(Stream stream)
		{
			await Task.Run(() =>
			{
				this.ReadFile(stream);
			});
		}

		public void ReadFile(Stream stream)
		{

			string line;

			using (var reader = new StreamReader(stream))
			{
				
				while (reader.Peek() >= 0)
				{

					while ((line = reader.ReadLine()) != null)
					{
						lock (_lock)
						{
							wordIndex++;
							this.theWords.TryAdd(wordIndex, line);
						}


					}
				}
			}
		}

		public void CountAllWords()
		{
            Console.WriteLine("Nr Total words = {0}",this.theWords.AsParallel().Count().ToString("N0"));
		}

		public void CountDistinctWords()
		{
			Console.WriteLine("Nr Distinct words = {0}", this.theWords.AsParallel().GroupBy(c => c).Count().ToString("N0"));
		}

		public void FindWord(string wordToFind)
		{
			//var foundWords = this.theWords.AsParallel().Where(c => c.Value.Contains(wordToFind)).ToList();
			var foundWords = this.theWords.AsParallel().Where(c => c.Value.Equals(wordToFind)).ToList();
			int found = 0;
			foreach (KeyValuePair<long, string> entry in foundWords)
			{
				Console.WriteLine("The speficied word [{0}] was found at index {1}",wordToFind, entry.Key);
            }	
			
		}




		public void GroupWords()
		{
			int[] categCount  = new int[4] { 0, 0, 0, 0 };

			Parallel.ForEach(this.theWords, (KeyValuePair<long, string> element) =>
			{

				if (element.Value.Length < 5)
				{
					//xs
					Interlocked.Add(ref categCount[0], 1);
				}
				if (element.Value.Length > 5 && element.Value.Length < 10)
				{
					//s
					Interlocked.Add(ref categCount[1], 1);
				}
				if (element.Value.Length > 10 && element.Value.Length < 15)
				{
					//m	
					Interlocked.Add(ref categCount[2], 1);
				}
				if (element.Value.Length > 15)
				{
					//XL
					Interlocked.Add(ref categCount[3], 1);
				}
			});

			int Index = 0;
			foreach (string categ in this.categs)
            {
                Console.WriteLine("Categ {0} has {1} words", categ, categCount[Index]);
				Index++;
            }
		}





	}
}
