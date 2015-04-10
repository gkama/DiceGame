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
	[Activity (Label = "Dice Master", MainLauncher = true, Icon = "@drawable/dicemastericon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button taketoDiceButton = FindViewById<Button> (Resource.Id.taketoDiceButton);
			Button taketoRegularDiceGameButton = FindViewById<Button> (Resource.Id.taketoRegularDiceGameButton);
			Button taketoHighLowDieGameButton = FindViewById<Button> (Resource.Id.taketoHighLowDieGameButton);
			Button taketoChuckALuckGameButton = FindViewById<Button> (Resource.Id.taketoChuckALuckGameButton);
			
			taketoDiceButton.Click += delegate {
				Intent slideIntent = new Intent(this, typeof(DiceCategoriesActivity));
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);
			};
			taketoRegularDiceGameButton.Click += delegate {
				Intent slideIntent = new Intent(this, typeof(RegularDiceActivity));
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);
			};

			taketoHighLowDieGameButton.Click += delegate {
				Intent slideIntent = new Intent(this, typeof(HighLowDiceActivity));
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);

			};

			taketoChuckALuckGameButton.Click += delegate {
				Intent slideIntent = new Intent(this, typeof(ChuckALuckActivity));
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);

			};
		}
	}
}


