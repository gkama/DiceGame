
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

namespace Animations
{
	[Activity (Label = "Matching Dice Game Categories!", Icon = "@drawable/dicemastericon")]			
	public class DiceCategoriesActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.DiceCategoriesScreen);

			Button oneSix = FindViewById<Button>(Resource.Id.oneSix);
			Button oneTwelve = FindViewById<Button>(Resource.Id.oneTwelve);
			Button oneEighteen = FindViewById<Button>(Resource.Id.oneEighteen);
			Button oneTwentyfour = FindViewById<Button>(Resource.Id.oneTwentyfour);
			Button oneThirty = FindViewById<Button>(Resource.Id.oneThirty);
			Button oneThirtysix = FindViewById<Button>(Resource.Id.oneThirtysix);

			Button backButton = FindViewById<Button> (Resource.Id.backButton);

			oneSix.Click += delegate {
				string categoryMax = "6";
				Intent slideIntent = new Intent(this, typeof(DiceActivity));
				slideIntent.PutExtra("catMax", categoryMax);
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);
			};
			oneTwelve.Click += delegate {
				string categoryMax = "12";
				Intent slideIntent = new Intent(this, typeof(DiceActivity));
				slideIntent.PutExtra("catMax", categoryMax);
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);
			};
			oneEighteen.Click += delegate {
				string categoryMax = "18";
				Intent slideIntent = new Intent(this, typeof(DiceActivity));
				slideIntent.PutExtra("catMax", categoryMax);
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);
			};
			oneTwentyfour.Click += delegate {
				string categoryMax = "24";
				Intent slideIntent = new Intent(this, typeof(DiceActivity));
				slideIntent.PutExtra("catMax", categoryMax);
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);
			};
			oneThirty.Click += delegate {
				string categoryMax = "30";
				Intent slideIntent = new Intent(this, typeof(DiceActivity));
				slideIntent.PutExtra("catMax", categoryMax);
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);
			};
			oneThirtysix.Click += delegate {
				string categoryMax = "36";
				Intent slideIntent = new Intent(this, typeof(DiceActivity));
				slideIntent.PutExtra("catMax", categoryMax);
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);
			};

			backButton.Click += delegate {
				Intent slideIntent = new Intent(this, typeof(MainActivity));
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);
			};
		}
	}
}

