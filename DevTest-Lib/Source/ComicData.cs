using System;

namespace DevTestLib
{
	public class ComicData : IComicDataSource
	{
		public string Name
		{
			get;
			private set;
		}

		public string Description
		{
			get;
			private set;
		}

		public ComicData (string name, string description)
		{
			Name = name;
			Description = description;
		}
	}
}

