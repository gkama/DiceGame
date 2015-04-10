
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
	[Activity (Label = "Regular Dice!", Icon = "@drawable/dicemastericon")]			
	public class RegularDiceActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.RegularDiceScreen);

			var numberResult = FindViewById<TextView> (Resource.Id.numberResult);

			Button diceButton = FindViewById<Button> (Resource.Id.diceButton);
			Button backButton = FindViewById<Button> (Resource.Id.backButton);

			numberResult.TextSize = 140;

			// Roll the dice button
			diceButton.Click += delegate {
				int resultR = RandomNumber (1, 6);
				numberResult.Text = resultR.ToString ();
			};

			// Back button
			backButton.Click += delegate {
				Intent slideIntent = new Intent(this, typeof(MainActivity));
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);
			};

		}

		// Randomizer
		private int RandomNumber (int minRange, int maxRange){
			Random randomNum = new Random();
			return randomNum.Next(minRange, maxRange + 1);
		}
	}
}

