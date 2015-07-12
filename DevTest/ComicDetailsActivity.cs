
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

			FindViewById<TextView>(Resource.Id.comicName).Text = comicName;
			FindViewById<TextView>(Resource.Id.comicDescription).Text = comicDesc;
		}
	}
}

