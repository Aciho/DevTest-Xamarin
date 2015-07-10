using System;

namespace DevTestLib
{
	public interface IParser
	{
	 	int Count { get; }
		string[] this [int i] {	get; }
	}
}

