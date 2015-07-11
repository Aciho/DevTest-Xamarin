using System;
using NUnit.Framework;
using DevTestLib;
using Android.Content.Res;
using System.IO;
using System.Collections.Generic;

namespace DevTestUnitTest
{
	[TestFixture]
	public class ComicList_Tests
	{
		TestDataSource source;
		ComicList comicList;

		class TestDataSource : IRawComicDataSource
		{
			public int Count { get { return 3; } }

			static string[][] data = 
			{
				new string[] {"1001 spot illustrations of the lively twenties","La Vie Parisienne","008077927","GB8865678","0486250210","","","","","Grafton, Carol Belanger","","","England","New York ; London","Dover ; Constable","1986","123 pages, chiefly illustrations, 28 cm","741.5944","YV.1988.b.2439","Design--History--20th century--Themes, motives ; Art deco ; French caricatures--1920-1930","","Illustrations from La Vie Parisienne"},
				new string[] {"Emerald warriors","","016062838","GBB233514","9780857684820 ; 0857684825","Tomasi, Peter","","person","","Tomasi, Peter ; Pasarin, Fernando","Green Lantern","1 [Green Lantern]","England","London","Titan","2012","1 v, chiefly colour illustrations, 26 cm","741.5","","Green Lantern (Fictitious character)--Comic books, strips, etc--Fiction","","Originally published: New York, N.Y.: DC Comics, 2011"},
				new string[] {"Thomas Nast : cartoons and illustrations","","009037808","GB7428296","0486229831 ; 0486230678","Nast, Thomas","","person","","Nast, Thomas ; St Hill, Thomas Nast","","","England","New York ; London","Dover Publications ; Constable","1974","ii-x, 146 pages, chiefly illustrations, portraits, 31 cm","741.5973","f75/40472","American wit and humor, Pictorial ; American cartoons--Collections from individual artists","",""}
			};
				
			public string[] this [int i] 
			{
				get 
				{ 
					return data [i];
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
			Assert.That(comicList.Count, Is.EqualTo(3));
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

		[Test]
		public void Favourites()
		{
			// Don't strictly need these, but just to be sure
			Assert.That(comicList[0].Name, Is.EqualTo("1001 spot illustrations of the lively twenties"));
			Assert.That(comicList[2].Name, Is.EqualTo("Thomas Nast : cartoons and illustrations"));

			comicList.ToggleFavourite (2);

			Assert.That(comicList[0].Name, Is.EqualTo("Thomas Nast : cartoons and illustrations"), "Favourites go to the top");
			Assert.That(comicList[1].Name, Is.EqualTo("1001 spot illustrations of the lively twenties"), "Everything else bumped down");
			Assert.That(comicList[3].Name, Is.EqualTo("Thomas Nast : cartoons and illustrations"), "Favourited items keep their place in the list, which is extended");
		}
	}
}

