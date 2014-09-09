using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TicTacToe
{
	[Activity (Label = "Tic-Tac-Toe", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView ( Resource.Layout.Main );

			// Resources
			Button Button1 = FindViewById <Button> (Resource.Id.Button1);
			Button Button2 = FindViewById <Button> (Resource.Id.Button2);
			Button Button3 = FindViewById <Button> (Resource.Id.Button3);

			// Resource CallBacks
			Button1.Click += delegate { 
				StartActivity ( typeof ( Game ) );
				Finish (); };

			Button2.Click += delegate { 
				StartActivity ( typeof ( Instructions ) );
				Finish (); };

			Button3.Click += delegate {	
				AlertDialog.Builder MessageBox = new AlertDialog.Builder ( this );
				MessageBox.SetNegativeButton ( "OK", delegate {} );
				MessageBox.SetMessage ("Xamarin Studio\n-Hussain Al-Homedawy.");
				MessageBox.Show (); };
		}
	}
}


