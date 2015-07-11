using System;

namespace DevTestLib
{
	public interface IComicDataSourceListWithFavourites : IComicDataSourceList
	{
		void ToggleFavourite(int position);
	}

	public interface IComicDataSourceList
	{
		int Count { get;}
		IComicDataSource this [int position] { get;}
	}

	public interface IComicDataSource
	{
		string Name { get; }
		string Description { get; }
	}
}

