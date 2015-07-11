using System;
using NUnit.Framework;
using DevTestLib;
using Android.Content.Res;
using System.IO;

namespace DevTestUnitTest
{
	[TestFixture]
	public class ComicList_Tests
	{
		TestDataSource source;
		ComicList comicList;

		class TestDataSource : IRawComicDataSource
		{
			public int Count { get { return 1; } }
			public string[] this [int i] 
			{
				get 
				{ 
					return new[] 
					{
						"1001 spot illustrations of the lively twenties",
						"La Vie Parisienne",
						"008077927",
						"GB8865678",
						"0486250210",
						"",
						"",
						"",
						"",
						"Grafton, Carol Belanger",
						"",
						"",
						"England",
						"New York ; London",
						"Dover ; Constable",
						"1986",
						"123 pages, chiefly illustrations, 28 cm",
						"741.5944",
						"YV.1988.b.2439",
						"Design--History--20th century--Themes, motives ; Art deco ; French caricatures--1920-1930",
						"",
						"Illustrations from La Vie Parisienne"
					}; 
				} 
			}
		}

		[SetUp]
		public void Setup()
		{
			source = new TestDataSource();
			comicList = new ComicList(source);
		}

		[TearDown]
		public void Tear()
		{
		}

		[Test]
		public void Count()
		{
			Assert.That(comicList.Count, Is.EqualTo(1));
		}

		[Test]
		public void Name()
		{
			Assert.That(comicList[0].Name, Is.EqualTo("1001 spot illustrations of the lively twenties"));
		}

		[Test]
		public void Description()
		{
			Assert.That(comicList[0].Description, Is.EqualTo("Design--History--20th century--Themes, motives ; Art deco ; French caricatures--1920-1930"));
		}
	}
}

