using System;
using NUnit.Framework;
using DevTestLib;

namespace DevTestUnitTest
{
	[TestFixture]
	public class PublisherList_Tests
	{
		PublisherList list;

		[SetUp]
		public void Setup()
		{
			list = new PublisherList();
		}

		[TearDown]
		public void Tear()
		{
		}

		[Test]
		public void Name()
		{
			Assert.That(list.GetCount("Name1"), Is.EqualTo(0));

			list.RecordInstance("Name1");

			Assert.That(list.GetCount("Name1"), Is.EqualTo(1));

			list.RecordInstance("Name1");

			Assert.That(list.GetCount("Name1"), Is.EqualTo(2));
			Assert.That(list.GetCount("Name2"), Is.EqualTo(0));
		}
	}
}

