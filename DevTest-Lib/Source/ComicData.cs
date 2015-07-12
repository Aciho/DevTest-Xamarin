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

		public ComicData (string name, string subtitle, string description, string publisher, string date)
		{
			Name = name;
			Subtitle = subtitle;
			Description = description;
			Publisher = publisher;
			Date = date;
		}
	}
}

