using System;
using NUnit.Framework;
using DevTestLib;
using Android.Content.Res;
using System.IO;

namespace DevTestUnitTest
{
	[TestFixture]
	public class CSVParser_Tests
	{
		AssetManager assets;
		Stream input;

		[SetUp]
		public void Setup()
		{
			assets = Android.App.Application.Context.Assets;
			input = assets.Open ("Data/titleTest2.csv");
		}

		[TearDown]
		public void Tear()
		{
			input.Close();
		}

		[Test]
		public void LoadingEmptyFile ()
		{
			var parser = new CSVParser(null);

			Assert.That(parser.Count, Is.EqualTo(0));		
		}

		[Test]
		public void LoadingTestFile ()
		{
			var parser = new CSVParser(input);

			Assert.That(parser.Count, Is.EqualTo(11));
		}

		[Test]
		public void FirstLineCorrect ()
		{
			var parser = new CSVParser(input);

			var testArray = new[] { "1001 spot illustrations of the lively twenties","La Vie Parisienne","008077927","GB8865678","0486250210","","","","","Grafton, Carol Belanger","","","England","New York ; London","Dover ; Constable","1986","123 pages, chiefly illustrations, 28 cm","741.5944","YV.1988.b.2439","Design--History--20th century--Themes, motives ; Art deco ; French caricatures--1920-1930","","Illustrations from La Vie Parisienne"};
			Assert.That(parser[0], Is.EqualTo(testArray));
		}	

		// Noticed this while debugging, there's an issue when the last element is empty
		[Test]
		public void FourthLineCorrect ()
		{
			var parser = new CSVParser(input);

			var testArray = new[] { "How Obelix fell into the magic potion","","015103770","GBA933631","9781444000269 ; 1444000268","Goscinny","1926-1977","person","","Goscinny ; Uderzo","","","England","London","Orion Children's","2009","1 v, chiefly illustrations, 29 cm","741.5","","Astérix (Fictitious character)--Comic books, strips, etc--Juvenile fiction ; Obelix (Fictitious character : Uderzo)--Comic books, strips, etc--Juvenile fiction","",""};
			Assert.That(parser[3], Is.EqualTo(testArray));
		}	
	}
}

