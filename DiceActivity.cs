using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Animations
{
	[Activity (Label = "Application", Icon = "@drawable/dragon")]
	public class DiceActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			int total = 0;
			int numberOfC = 0;

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.DiceScreen);

			// Data passed - Category max
			string catMax = Intent.GetStringExtra("catMax") ?? "Data is not available!";
			int categoryMax = Int32.Parse(catMax);

			var numberResult = FindViewById<TextView> (Resource.Id.numberResult);
			var matchNumber = FindViewById<TextView> (Resource.Id.matchNumber);
			var categoryText = FindViewById<TextView> (Resource.Id.categoryText);
			var totalScore = FindViewById<TextView> (Resource.Id.totalScore);
			var numberOfClicks = FindViewById<TextView> (Resource.Id.numberOfClicks);

			Button diceButton = FindViewById<Button> (Resource.Id.diceButton);
			Button backButton = FindViewById<Button> (Resource.Id.backButton);

			// Categories - Radio Buttons
			numberResult.TextSize = 110;
			matchNumber.TextSize = 130;
			categoryText.TextSize = 30;

			categoryText.Text = "CATEGORY: 1-" + categoryMax;

			// Radio Buttons clicked
			diceButton.Click += delegate {
				int resultR = RandomNumber (1, categoryMax);
				numberResult.Text = resultR.ToString ();
				int resultM = RandomMatchNumber (1, 36);
				matchNumber.Text = resultM.ToString();

				// See if it matches
				if (resultR == resultM) {
					Toast.MakeText (this, "Awesome Stuff! It's a MATCH!", ToastLength.Long).Show();
				}

				// Add total & display it
				total += resultR;
				totalScore.Text = "Total: " + total.ToString();

				// Number of clicks counter
				numberOfC += 1;
				numberOfClicks.Text = "Number of Clicks: " + numberOfC.ToString();
			};

			// Back Button
			backButton.Click += delegate {
				Intent slideIntent = new Intent(this, typeof(DiceCategoriesActivity));
				Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim1, Resource.Animation.Anim2).ToBundle();
				StartActivity(slideIntent, slideAnim);
			};
		}
			
		// Randomizer
		private int RandomNumber (int minRange, int maxRange){
			Random randomNum = new Random();
			return randomNum.Next(minRange, maxRange + 1);
		}

		// Random Match
		private int RandomMatchNumber (int minRange, int maxRange){
			Random r = new Random ();
			return r.Next (minRange, maxRange + 1);
		}
	}
}


