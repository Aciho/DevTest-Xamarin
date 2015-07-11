using System;
using System.Collections.Generic;

namespace DevTestLib
{
	public class ComicList : IComicDataSourceList
	{
		public int Count
		{
			get
			{
				return 0;
			}
		}

		public IComicDataSource this[int position]
		{
			get
			{
				return null;
			}
		}

		public ComicList (IRawComicDataSource dataSource)
		{
		}
	}
}

