using System;
using Android.Widget;
using DevTestLib;
using Android.App;
using System.Collections.Generic;
using Android.Views;

namespace DevTest
{
	public class ComicDataAdapter: BaseAdapter<IComicDataSource>, Android.Widget.AdapterView.IOnItemClickListener
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
			// Get our object for position
			var item = source[position];			

			//Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
			// gives us some performance gains by not always inflating a new view
			// will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
			var view = (convertView ?? 
				context.LayoutInflater.Inflate(
					Android.Resource.Layout.SimpleListItemChecked, 
					parent, 
					false));

			// Find references to each subview in the list item's view
			var txtName = view.FindViewById<TextView>(Android.Resource.Id.Text1);

			//Assign item's values to the various subviews
			txtName.SetText (item.Name, TextView.BufferType.Normal);

			//Finally return the view
			return view;
		}

		public void OnItemClick(AdapterView parent, View view, int position, long id)
		{
			var t = source[position];
			Android.Widget.Toast.MakeText(context, t.Description, Android.Widget.ToastLength.Short).Show();
		}
	}
}

