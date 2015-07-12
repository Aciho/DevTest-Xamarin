using System;
using System.Collections.Generic;

namespace DevTestLib
{
	public class ComicList : IComicDataSourceListWithFavourites
	{
		readonly int MAX_FAVOURITES = 10;

		public void ToggleFavourite(int position)
		{
			if (position < favourites.Count)
			{
				favourites.RemoveAt(position);
			}
			else
			{
				int dataIndex = position - favourites.Count;

				if (favourites.Contains(dataIndex))
				{
					favourites.Remove(dataIndex);
				} 
				else if (favourites.Count < MAX_FAVOURITES)
				{
					favourites.Add(dataIndex);
					favourites.Sort();
				}
			}
		}

		public bool IsFavourite(int position)
		{
			if (position < favourites.Count)
			{
				return true;
			}

			return favourites.Contains(position - favourites.Count);
		}

		public int GetPublisherCount(string publisher)
		{
			return publishers.GetCount(publisher);
		}

		public int[] Favourites
		{
			get
			{
				return favourites.ToArray();
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
		List<ComicData> data = new List<ComicData> ();
		PublisherList publishers = new PublisherList();

		public ComicList (IRawComicDataSource dataSource)
		{
			for (int i = 0; i < dataSource.Count; ++i)
			{
				var comicItem = Parse(dataSource[i]);
				data.Add(comicItem);
				publishers.RecordInstance(comicItem.Publisher);
			}
		}

		ComicData Parse(string[] rawData)
		{
			return new ComicData (rawData[0], rawData[1], rawData[19], rawData[14], rawData[15]);
		}
	}
}

