using System;

namespace DevTestLib
{
	public interface IPublisherList
	{
		void RecordInstance(string name);
		int GetCount(string name);
	}
}

