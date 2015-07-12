using System;

namespace DevTestLib
{
	public interface IComicDataSourceListWithFavourites : IComicDataSourceList
	{
		void ToggleFavourite(int ID);
		bool IsFavourite(int ID);
		int GetPublisherCount(string publisher);

		int[] Favourites { get; }
	}

	public interface IComicDataSourceList
	{
		int Count { get;}
		IComicDataSource this [int position] { get;}
	}

	public interface IComicDataSource
	{
		int ID { get; }
		string Name { get; }
		string Subtitle { get; }
		string Description { get; }
		string Publisher { get; }
		string Date { get; }
	}
}

