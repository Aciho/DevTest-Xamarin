using System;
using System.Collections.Generic;

namespace DevTestLib
{
	public class ComicList : IComicDataSourceListWithFavourites
	{
		readonly int MAX_FAVOURITES = 10;

		public void ToggleFavourite(int ID)
		{
			if (favourites.Contains(ID))
			{
				favourites.Remove(ID);
			} 
			else if (favourites.Count < MAX_FAVOURITES)
			{
				favourites.Add(ID);
				favourites.Sort();
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
				var comicItem = new ComicData (i, dataSource[i][0], dataSource[i][1], dataSource[i][19], dataSource[i][14], dataSource[i][15]);
				data.Add(comicItem);
				publishers.RecordInstance(comicItem.Publisher);
			}
		}
	}
}

