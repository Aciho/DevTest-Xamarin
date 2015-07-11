using System;
using System.Collections.Generic;

namespace DevTestLib
{
	public class ComicList : IComicDataSourceListWithFavourites
	{
		readonly int MAX_FAVOURITES = 10;

		public void ToggleFavourite(int position)
		{
			if (favourites.Contains (position))
			{
				favourites.Remove (position);
			} 
			else if (favourites.Count < MAX_FAVOURITES)
			{
				favourites.Add (position);
				favourites.Sort();
			}
		}

		public int Count
		{
			get
			{
				if (data == null)
					return 0;
				
				return data.Count + favourites.Count;
			}
		}

		public IComicDataSource this[int position]
		{
			get
			{
				if (position >= Count)
					return null;

				if (position < favourites.Count)
				{
					return data[favourites[position]];
				}

				return data[position - favourites.Count];
			}
		}

		List<int> favourites = new List<int>();
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

