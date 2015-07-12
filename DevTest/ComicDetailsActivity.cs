
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DevTestLib;

namespace DevTest
{
	[Activity(Label = "Comic Details")]			
	public class ComicDetailsActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Create your application here
			SetContentView(Resource.Layout.ComicDetails);

			var comicName = Intent.GetStringExtra("ComicName");
			var comicDesc = Intent.GetStringExtra("ComicDescription");
			var comicPubl = Intent.GetStringExtra("ComicPublisher");
			var comicDate = Intent.GetStringExtra("ComicDate");
			var position = Intent.GetIntExtra("Position", 0);
			var favourite = Intent.GetBooleanExtra("Favourite", false);
			var otherComics = Intent.GetIntExtra("OtherComics", 0);

			FindViewById<TextView>(Resource.Id.comicName).Text = comicName;
			FindViewById<TextView>(Resource.Id.comicDescription).Text = comicDesc;
			FindViewById<TextView>(Resource.Id.comicPublisher).Text = comicPubl;
			FindViewById<TextView>(Resource.Id.comicDate).Text = comicDate;

			SetFavouriteButtonText(favourite);

			FindViewById<TextView>(Resource.Id.otherComics).Text = otherComics + " " + GetString(Resource.String.other_comics);

			FindViewById<Button>(Resource.Id.favouriteButton).Click += (object sender, EventArgs e) => 
			{
				Console.WriteLine("FavClick " + position);
				MainActivity.ToggleFavourite(position);
				favourite = !favourite;
				SetFavouriteButtonText(favourite);
			};

			FindViewById<Button>(Resource.Id.closeButton).Click += (object sender, EventArgs e) => 
			{
				OnBackPressed();
			};
		}

		void SetFavouriteButtonText(bool favourite)
		{
			FindViewById<Button>(Resource.Id.favouriteButton).Text = favourite ? GetString(Resource.String.remove_fav) : GetString(Resource.String.add_fav);
		}
	}
}

