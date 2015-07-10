using System;
using System.IO;
using System.Collections.Generic;

namespace DevTestLib
{
	public class CSVParser : IParser
	{
		public int Count 
		{ 
			get 
			{ 
				if (parsedCSV == null)
					return 0;
				
				return parsedCSV.Length; 
			} 
		}

		public string[] this[int i]
		{
			get 
			{
				if (i >= Count)
					return new string[0];
				
				return parsedCSV[i];
			}
		}

		private string[][] parsedCSV = null;

		private readonly char[] trimChars = { '"' };
		private readonly string[] splitStrings = { "\",\"" };

		public CSVParser (Stream input)
		{
			if (input == null)
				return;

			var reader = new StreamReader (input, System.Text.Encoding.UTF8, true, 2048);

			if (reader.EndOfStream)
				return;

			reader.ReadLine (); // Ditch the titles

			if (reader.EndOfStream)
				return;
			
			var stringList = new List<string[]> ();

			string line;


			while (!reader.EndOfStream)
			{
				line = reader.ReadLine();							
				var items = line.Split(splitStrings, StringSplitOptions.None);		// split on "," to avoid splitting in mid text
																					// keep empty entries

				items[0] = items[0].Trim (trimChars); // Take the quotes off the ends of the first and last strings
				items[items.Length-1] = items[items.Length-1].Trim (trimChars);

				stringList.Add (items);
			}

			//TODO: We should probably check if the lines are all the same length here
			parsedCSV = stringList.ToArray();
		}
	}
}
