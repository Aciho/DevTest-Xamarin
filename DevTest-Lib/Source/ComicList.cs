using System;
using System.Collections.Generic;

namespace DevTestLib
{
	public class ComicList : IComicDataSourceList
	{
		public int Count
		{
			get
			{
				if (data == null)
					return 0;
				return data.Count;
			}
		}

		public IComicDataSource this[int position]
		{
			get
			{
				if (position >= Count)
					return null;
				
				return data[position];
			}
		}

		List<ComicData> data;

		public ComicList (IRawComicDataSource dataSource)
		{
			data = new List<ComicData> ();

			for (int i = 0; i < dataSource.Count; ++i)
			{
				data.Add(Parse(dataSource [i]));
			}
		}

		ComicData Parse(string[] rawData)
		{
			return new ComicData (rawData [0], rawData [19]);
		}
	}
}

