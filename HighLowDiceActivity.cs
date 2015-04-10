
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
	[Activity (Label = "High-Low Dice!", Icon = "@drawable/dicemastericon")]			
	public class HighLowDiceActivity : Activity
	{
		private static readonly Random randomNum = new Random();
		private static readonly object syncLock = new object();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.HighLowDiceScreen);

			var numberResult1 = FindViewById<TextView> (Resource.Id.numberResult1);
			var numberResult2 = FindViewById<TextView> (Resource.Id.numberResult2);
			var highlowText = FindViewById<TextView> (Resource.Id.highlowText);
			var sumRoll = FindViewById<TextView> (Resource.Id.sumRoll);

			Button diceButton = FindViewById<Button> (Resource.Id.diceButton);
			Button backButton = FindViewById<Button> (Resource.Id.backButton);

			numberResult1.TextSize = 110;
			numberResult2.TextSize = 110;
			highlowText.TextSize = 20;
			sumRoll.TextSize = 20;

			// Roll the dice button
			diceButton.Click += delegate {
				int resultR1 = RandomNumber (1, 6);
				int resultR2 = RandomNumber (1, 6);
				int totalR = resultR1 + resultR2;

				numberResult1.Text = resultR1.ToString ();
				numberResult2.Text = resultR2.ToString ();

				if(totalR > 7){ highlowText.Text = "It's HIGH!";}
				else if(totalR < 7){ highlowText.Text = "It's LOW!";}
				else { highlowText.Text = "It's SEVEN!";}

				sumRoll.Text = totalR.ToString();
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
			lock(syncLock) {
				return randomNum.Next(minRange, maxRange + 1);
			}
		}
	}
}

