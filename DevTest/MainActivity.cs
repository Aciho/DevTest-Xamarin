using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DevTestLib;

namespace DevTest
{
	[Activity(Label = "Dev Test", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		ComicDataAdapter comicAdapter;
		ListView comicListView;

		// OK, really not happy about this, but everything I've found so far says this is the way to do it
		static IComicDataSourceListWithFavourites data;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			comicListView = FindViewById<ListView>(Resource.Id.ComicList);
			comicListView.ChoiceMode = ChoiceMode.Multiple;
			comicListView.FastScrollEnabled = true;

			data = new ComicList (new CSVParser (Assets.Open ("Data/titles.csv")));

			// wire up task click handler
			if(comicListView != null) {
				comicListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => 
				{
					// Starting to think I should just serialize this
					var comicDetails = new Intent (this, typeof (ComicDetailsActivity));
					comicDetails.PutExtra("ComicName", data[e.Position].Name);
					comicDetails.PutExtra("ComicDescription", data[e.Position].Description);
					comicDetails.PutExtra("ComicPublisher", data[e.Position].Publisher);
					comicDetails.PutExtra("ComicDate", data[e.Position].Date);
					comicDetails.PutExtra("ID", data[e.Position].ID);
					comicDetails.PutExtra("Favourite", data.IsFavourite(e.Position));
					comicDetails.PutExtra("OtherComics", data.GetPublisherCount(data[e.Position].Publisher) - 1);
					StartActivity (comicDetails);
				};
			}
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			// create our adapter
			comicAdapter = new ComicDataAdapter(this, data);

			//Hook up our adapter to our ListView
			comicListView.Adapter = comicAdapter;

			for (int i = 0; i < data.Favourites.Length; i++)
			{
				var id = data.Favourites[i];
				var position = id + data.Favourites.Length;
				comicListView.SetItemChecked(i, true);
				comicListView.SetItemChecked(position, true);
			}
		}

		public static void ToggleFavourite(int id)
		{
			data.ToggleFavourite(id);
		}
	}
			
}


