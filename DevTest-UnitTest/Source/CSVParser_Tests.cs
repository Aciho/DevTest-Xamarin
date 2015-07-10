using System;
using NUnit.Framework;
using DevTestLib;


namespace DevTestUnitTest
{
	[TestFixture]
	public class CSVParser_Tests
	{
		[SetUp]
		public void Setup ()
		{
		}

		[TearDown]
		public void Tear ()
		{
		}

		[Test]
		public void LoadingEmptyFile ()
		{
			var parser = new CSVParser("");

			Assert.True (parser.Count == 0);
		}

		[Test]
		public void LoadingTestFile ()
		{
			var parser = new CSVParser("Data/titleTest2.csv");

			Assert.True (parser.Count == 11);
		}

		[Test]
		public void FirstLineCorrect ()
		{
			var parser = new CSVParser("Data/titleTest2.csv");

			var testArray = new[] { "1001 spot illustrations of the lively twenties","La Vie Parisienne","008077927","GB8865678","0486250210","","","","","Grafton, Carol Belanger","","","England","New York ; London","Dover ; Constable","1986","123 pages, chiefly illustrations, 28 cm","741.5944","YV.1988.b.2439","Design--History--20th century--Themes, motives ; Art deco ; French caricatures--1920-1930","","Illustrations from La Vie Parisienne"};
			Assert.True (parser[0] == testArray);
		}	
	}
}

