using System;

namespace DevTestLib
{
	public class ComicData : IComicDataSource
	{
		public int ID
		{
			get;
			private set;
		}

		public string Name
		{
			get;
			private set;
		}

		public string Subtitle
		{
			get;
			private set;
		}

		public string Description
		{
			get;
			private set;
		}
		public string Publisher
		{
			get;
			private set;
		}

		public string Date
		{
			get;
			private set;
		}

		public ComicData (int id, string name, string subtitle, string description, string publisher, string date)
		{
			ID = id;
			Name = name;
			Subtitle = subtitle;
			Description = description;
			Publisher = publisher;
			Date = date;
		}
	}
}

