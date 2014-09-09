
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

namespace TicTacToe
{
	[Activity (Label = "Instructions")]			
	public class Instructions : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Display the window
			SetContentView (Resource.Layout.Instructions);

			// Resources
			Button Button5 = FindViewById <Button> (Resource.Id.Button5);

			// Resource CallBacks
			Button5.Click += delegate { 
				StartActivity ( typeof ( MainActivity ) );
				Finish (); };
		}
	}
}

