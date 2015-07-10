using System;

namespace DevTestLib
{
	public class CSVParser : IParser
	{
		public int Count { get { return 0; } }

		public string[] this[int i]
		{
			get 
			{
				return new string[] { };
			}
		}

		public CSVParser (string assetName)
		{
		}
	}
}
