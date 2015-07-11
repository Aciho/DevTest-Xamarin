using System;
using Android.Widget;
using DevTestLib;
using Android.App;
using System.Collections.Generic;

namespace DevTest
{
	public class ComicDataAdapter: BaseAdapter<IComicDataSource>
	{
		Activity context = null;
		IComicDataSourceList source;

		public ComicDataAdapter (Activity context, IComicDataSourceList source) : base ()
		{
			this.context = context;
			this.source = source;
		}

		public override IComicDataSource this[int position]
		{
			get { return source[position]; }
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count
		{
			get { return source.Count; }
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			try
			{
				// Get our object for position
				var item = source[position];			

				//Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
				// gives us some performance gains by not always inflating a new view
				// will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
				var view = (convertView ?? 
					context.LayoutInflater.Inflate(
						Resource.Layout.ComicListItem, 
						parent, 
						false)) as RelativeLayout;

				// Find references to each subview in the list item's view
				var txtName = view.FindViewById<Button>(Resource.Id.comicButton);
				//			var txtDescription = view.FindViewById<TextView>(Resource.Id.DescriptionText);

				//Assign item's values to the various subviews
				txtName.SetText (item.Name, TextView.BufferType.Normal);
				//			txtDescription.SetText (item.Description, TextView.BufferType.Normal);

				//Finally return the view
				return view;
			}
			catch (Exception)
			{
				return null;
			}


		}
	}
}

