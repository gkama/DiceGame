using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Animation;

namespace Animations
{
	[Activity (Label = "Application", MainLauncher = true, Icon = "@drawable/dragon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button taketoDiceButton = FindViewById<Button> (Resource.Id.taketoDiceButton);
			Button taketoRouletteButton = FindViewById<Button> (Resource.Id.rouletteButton);
			
			taketoDiceButton.Click += delegate {
				Intent slideIntent = new Intent(this, typeof(DiceCategoriesActivity));
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);
			};
			taketoRouletteButton.Click += delegate {
				Intent slideIntent = new Intent(this, typeof(RouletteActivity));
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);
			};
		}
	}
}


