using System;
using System.Collections.Generic;

namespace DevTestLib
{
	public class PublisherList : IPublisherList
	{
		public void RecordInstance(string name)
		{
			publishers[name] = GetCount(name) + 1;
		}

		public int GetCount(string name)
		{
			int count;
			publishers.TryGetValue(name, out count); // TryGetValue will set count to 0 if the item doesn't exist
			return count;
		}

		Dictionary<string, int> publishers = new Dictionary<string, int>();
	}
}

