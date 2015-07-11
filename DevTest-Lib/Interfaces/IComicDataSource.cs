using System;

namespace DevTestLib
{
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

