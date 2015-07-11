using System;

namespace DevTestLib
{
	public interface IRawComicDataSource
	{
	 	int Count { get; }
		string[] this [int i] {	get; }
	}
}

