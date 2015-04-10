
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
	public class ChuckALuckActivity : Activity
	{
		private static readonly Random randomNum = new Random();
		private static readonly object syncLock = new object();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.ChuckALuckScreen);

			int match = 0;

			var numberResult1 = FindViewById<TextView> (Resource.Id.numberResult1);
			var numberResult2 = FindViewById<TextView> (Resource.Id.numberResult2);
			var numberResult3 = FindViewById<TextView> (Resource.Id.numberResult3);

			var matchText = FindViewById<TextView> (Resource.Id.matchText);
			var userInput = FindViewById<EditText> (Resource.Id.userInput);

			Button diceButton = FindViewById<Button> (Resource.Id.diceButton);
			Button backButton = FindViewById<Button> (Resource.Id.backButton);

			numberResult1.TextSize = 110;
			numberResult2.TextSize = 110;
			numberResult3.TextSize = 110;
			matchText.TextSize = 20;

			// Roll the dice button
			diceButton.Click += delegate {
				int resultR1 = RandomNumber (1, 6);
				int resultR2 = RandomNumber (1, 6);
				int resultR3 = RandomNumber (1, 6);

				int totalR = resultR1 + resultR2 + resultR3;

				numberResult1.Text = resultR1.ToString ();
				numberResult2.Text = resultR2.ToString ();
				numberResult3.Text = resultR3.ToString ();

				if(resultR1.ToString() == userInput.Text.ToString()) {
					match += 1;
					matchText.Text = "MATCHES: " + match;
				}
				if(resultR2.ToString() == userInput.Text.ToString()){
					match += 1;
					matchText.Text = "MATCHES: " + match;
				}
				if(resultR3.ToString() == userInput.Text.ToString()){ 
					match += 1;
					matchText.Text = "MATCHES: " + match;
				}
				if(resultR1.ToString() != userInput.Text.ToString() && resultR2.ToString() != userInput.Text.ToString() &&
				   resultR3.ToString() != userInput.Text.ToString()){
					match = 0;
					matchText.Text = "MATCHES: " + match;
				}
				match = 0;
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

