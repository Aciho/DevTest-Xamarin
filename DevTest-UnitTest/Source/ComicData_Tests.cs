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
			data1 = new ComicData ("Name", "Desc");
			data2 = new ComicData ("OtherName", "OtherDesc");
		}

		[TearDown]
		public void Tear()
		{
		}

		[Test]
		public void Name()
		{
			Assert.That(data1.Name, Is.EqualTo("Name"));
			Assert.That(data2.Name, Is.EqualTo("OtherName"));
		}

		[Test]
		public void Description()
		{
			Assert.That(data1.Description, Is.EqualTo("Desc"));
			Assert.That(data2.Description, Is.EqualTo("OtherDesc"));
		}
	}
}

