using System;
using NUnit.Framework;
using DevTestLib;
using Android.Content.Res;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DevTestUnitTest
{
	[TestFixture]
	public class ComicList_Tests
	{
		TestDataSource source;
		ComicList comicList;

		class TestDataSource : IRawComicDataSource
		{
			public int Count { get { return data.Length; } }

			static string[][] data = 
			{
				new string[] {"1001 spot illustrations of the lively twenties","La Vie Parisienne","008077927","GB8865678","0486250210","","","","","Grafton, Carol Belanger","","","England","New York ; London","Dover ; Constable","1986","123 pages, chiefly illustrations, 28 cm","741.5944","YV.1988.b.2439","Design--History--20th century--Themes, motives ; Art deco ; French caricatures--1920-1930","","Illustrations from La Vie Parisienne"},
				new string[] {"Are we there yet? : a Frank and Ernest history of the world","","012030669","GB9168045","1853042250","Thaves, Bob","","person","","Thaves, Bob","","","England","Horsham","Ravette Books","1989","[127] pages, chiefly illustrations, 13x21 cm","741.5973","YK.1992.a.10449","Humorous cartoons ; United States","","Originally published: New York : Topper Books, 1988"},
				new string[] {"Emerald warriors","","016062838","GBB233514","9780857684820 ; 0857684825","Tomasi, Peter","","person","","Tomasi, Peter ; Pasarin, Fernando","Green Lantern","1 [Green Lantern]","England","London","Titan","2012","1 v, chiefly colour illustrations, 26 cm","741.5","","Green Lantern (Fictitious character)--Comic books, strips, etc--Fiction","","Originally published: New York, N.Y.: DC Comics, 2011"},
				new string[] {"How Obelix fell into the magic potion","","015103770","GBA933631","9781444000269 ; 1444000268","Goscinny","1926-1977","person","","Goscinny ; Uderzo","","","England","London","Orion Children's","2009","1 v, chiefly illustrations, 29 cm","741.5","","Astérix (Fictitious character)--Comic books, strips, etc--Juvenile fiction ; Obelix (Fictitious character : Uderzo)--Comic books, strips, etc--Juvenile fiction","",""},
				new string[] {"More constant minx","","012216745","GB6118131","","Raymonde","","person","","Raymonde","","","United Kingdom","","Hammond","1961","45 pages,illustrations, 17 cm","741.59","","","",""},
				new string[] {"Smeegin W. I. Smirk cartoons","","012021978","GB9005299","0900662581","","","","","","","","England","Lerwick","Shetland Times","1987","[64] pages, 15x21 cm","741.59411","YV.1990.a.297","Scottish wit and humor, Pictorial ; Scottish humorous cartoons","",""},
				new string[] {"The best of Mac, 2000-2009 : a decade of cartoons from the Daily Mail","","015327677","GBA970373","9781906032739 ; 1906032734","McMurtry, Stan","1936-","person","","McMurtry, Stan ; Bryant, Mark","","","England","London","Portico","2009","1 v. (unpaged), chiefly illustrations, 18 x 25 cm","741.56941","LC.31.a.9110","English wit and humor, Pictorial ; Caricatures and cartoons--Great Britain","",""},
				new string[] {"The king of beasts & other creatures","","008082748","GB8101035","0713913363","Searle, Ronald","1920-2011","person","","Searle, Ronald","","","England","London","Allen Lane","1980","[56] pages, chiefly colour illustrations, 23x24 cm","741.5942","L.49/643","English wit and humor, Pictorial ; Animals--Caricatures and cartoons ; English humorous cartoons--Collections","","Col. ill on lining papers"},
				new string[] {"Thomas Nast : cartoons and illustrations","","009037808","GB7428296","0486229831 ; 0486230678","Nast, Thomas","","person","","Nast, Thomas ; St Hill, Thomas Nast","","","England","New York ; London","Dover Publications ; Constable","1974","ii-x, 146 pages, chiefly illustrations, portraits, 31 cm","741.5973","f75/40472","American wit and humor, Pictorial ; American cartoons--Collections from individual artists","",""},
				new string[] {"What is it, Tink, is Pan in trouble?","","010348111","GB98W5176","0836218868","Trudeau, G. B. (Garry B.)","1948-","person","","Trudeau, G. B. (Garry B.)","","","England","Sl","Andrews McMeel","1998","96 pages, chiefly illustrations, 23 cm","741.5973","","","","Originally published: London: Fourth Estate, 1992"},
				new string[] {"2000 AD","The complete Judge Dredd in Oz","012029155","GB9474205","1852864362","Wagner, John","1949-","person","","Wagner, John ; Grant, Alan ; Robinson, Cliff","","","England","London","Titan","1994","1 v, chiefly illustrations, 28 cm","741.5942","YK.1994.b.13625","Strip cartoons ; England","","Originally published in: 2000 AD progs, 545-570. - Previous ed. in 3 vols.: 1988"}
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
			Assert.That(comicList.Count, Is.EqualTo(11));
		}

		[Test]
		public void Name()
		{
			Assert.That(comicList[0].Name, Is.EqualTo("1001 spot illustrations of the lively twenties"));
		}

		[Test]
		public void Subtitle()
		{
			Assert.That(comicList[0].Subtitle, Is.EqualTo("La Vie Parisienne"));
		}

		[Test]
		public void Description()
		{
			Assert.That(comicList[0].Description, Is.EqualTo("Design--History--20th century--Themes, motives ; Art deco ; French caricatures--1920-1930"));
		}

		[Test]
		public void Publisher()
		{
			// Cheating a little here, but the publisher data for the first one seems a bit broken
			// We should really do some data validation at some point
			Assert.That(comicList[1].Publisher, Is.EqualTo("Ravette Books"));
		}

		[Test]
		public void Date()
		{
			Assert.That(comicList[1].Date, Is.EqualTo("1989"));
		}

		[Test]
		public void AddFavourites()
		{
			comicList.ToggleFavourite (2);

			Assert.That(comicList[0].Name, Is.EqualTo("Emerald warriors"), "Favourites go to the top");
			Assert.That(comicList[1].Name, Is.EqualTo("1001 spot illustrations of the lively twenties"), "Everything else bumped down");
			Assert.That(comicList.Count, Is.EqualTo(12), "Favourites increase the size of the list");
			Assert.That(comicList[3].Name, Is.EqualTo("Emerald warriors"), "Favourited items keep their place in the list");
		}

		[Test]
		public void OrderFavourites()
		{
			comicList.ToggleFavourite (3);
			comicList.ToggleFavourite (3); // Adding a favourite shuffles the list down by one

			Assert.That(comicList[0].Name, Is.EqualTo("Emerald warriors"), "Favourites go to the top in their original order, not selection order");
		}

		[Test]
		public void RemoveFavourites()
		{
			comicList.ToggleFavourite (2);
			comicList.ToggleFavourite (3); // Adding a favourite shuffles the list down by one

			Assert.That(comicList[0].Name, Is.EqualTo("1001 spot illustrations of the lively twenties"), "Toggling twice removes favourites");
			Assert.That(comicList.Count, Is.EqualTo(11));

		}

		[Test]
		public void FavouritesAndOrdering()
		{
			comicList.ToggleFavourite (2);
			comicList.ToggleFavourite (3);
			comicList.ToggleFavourite (4);

			comicList.ToggleFavourite(1); // Since favourited are at the top, this should unfavourite item 3

			Assert.That(comicList[1].Name, Is.EqualTo("More constant minx"), "Toggling near the top of the lis removes the correct item");
			Assert.False(comicList.Favourites.Contains(3), "Item removed properly");
			Assert.False(comicList.Favourites.Contains(1), "Other item not added");

		}

		[Test]
		public void LimitFavourites()
		{
			comicList.ToggleFavourite (10);
			comicList.ToggleFavourite (10);
			comicList.ToggleFavourite (10);
			comicList.ToggleFavourite (10);
			comicList.ToggleFavourite (10);
			comicList.ToggleFavourite (10);
			comicList.ToggleFavourite (10);
			comicList.ToggleFavourite (10);
			comicList.ToggleFavourite (10);
			comicList.ToggleFavourite (10);

			Assert.That(comicList.Count, Is.EqualTo(21), "Can add 10 favourites");

			comicList.ToggleFavourite (10);

			Assert.That(comicList.Count, Is.EqualTo(21), "Cannot add more than 10 favourites");
		}

		[Test]
		public void IsFavourite()
		{
			comicList.ToggleFavourite (3);

			Assert.True(comicList.IsFavourite(0), "Favourite check in top position");
			Assert.True(comicList.IsFavourite(4), "Favourite check in regular position");
			Assert.False(comicList.IsFavourite(3), "Non favourite check");
		}

		[Test]
		public void PublisherCount()
		{
			Assert.That(comicList.GetPublisherCount("Not a publisher"), Is.EqualTo(0));
			Assert.That(comicList.GetPublisherCount("Orion Children's"), Is.EqualTo(1));
			Assert.That(comicList.GetPublisherCount("Titan"), Is.EqualTo(2));
		}
	}
}

