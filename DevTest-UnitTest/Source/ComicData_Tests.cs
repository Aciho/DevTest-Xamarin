using System;
using NUnit.Framework;
using DevTestLib;

namespace DevTestUnitTest
{
	[TestFixture]
	public class ComicData_Tests
	{
		ComicData data1, data2;

		[SetUp]
		public void Setup()
		{
			data1 = new ComicData (0, "Name", "Subtitle", "Desc", "Publisher", "1966");
			data2 = new ComicData (2, "OtherName","OtherSubtitle", "OtherDesc", "OtherPublisher", "2013");
		}

		[TearDown]
		public void Tear()
		{
		}

		[Test]
		public void ID()
		{
			Assert.That(data1.ID, Is.EqualTo(0));
			Assert.That(data2.ID, Is.EqualTo(2));
		}

		[Test]
		public void Name()
		{
			Assert.That(data1.Name, Is.EqualTo("Name"));
			Assert.That(data2.Name, Is.EqualTo("OtherName"));
		}

		[Test]
		public void Subtitle()
		{
			Assert.That(data1.Subtitle, Is.EqualTo("Subtitle"));
			Assert.That(data2.Subtitle, Is.EqualTo("OtherSubtitle"));
		}

		[Test]
		public void Description()
		{
			Assert.That(data1.Description, Is.EqualTo("Desc"));
			Assert.That(data2.Description, Is.EqualTo("OtherDesc"));
		}

		[Test]
		public void Publisher()
		{
			Assert.That(data1.Publisher, Is.EqualTo("Publisher"));
			Assert.That(data2.Publisher, Is.EqualTo("OtherPublisher"));
		}

		[Test]
		public void Date()
		{
			Assert.That(data1.Date, Is.EqualTo("1966"));
			Assert.That(data2.Date, Is.EqualTo("2013"));
		}
	}
}

