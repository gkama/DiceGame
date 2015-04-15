/*
 *  Author: Georgi Kamacharov
 *  Date: 4/15/2015
 *  Description: View about screen/activity
 * 
*/

using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Animations
{
	[Activity (Label = "Dice Master", Icon = "@drawable/dicemastericon")]
	public class DiceActivity : Activity, GestureDetector.IOnGestureListener
	{
		private GestureDetector gestureDetector;

		private static int SWIPE_THRESHOLD = 100;
		private static int SWIPE_VELOCITY_THRESHOLD = 100;
		public static String MDG_DATA = "MDGData";

		private static readonly Random randomNum = new Random();
		private static readonly object syncLock = new object();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			int total = 0;
			float numberOfC = 0;
			float numberOfM = 0;
			float accuracy = 0;

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.DiceScreen);

			// Data passed - Category max
			string catMax = Intent.GetStringExtra("catMax") ?? "Data is not available!";
			int categoryMax = Int32.Parse(catMax);

			var numberResult = FindViewById<TextView> (Resource.Id.numberResult);
			var matchNumber = FindViewById<TextView> (Resource.Id.matchNumber);
			var categoryText = FindViewById<TextView> (Resource.Id.categoryText);
			var titleText = FindViewById<TextView> (Resource.Id.titleText);
			var totalScore = FindViewById<TextView> (Resource.Id.totalScore);
			var numberOfClicks = FindViewById<TextView> (Resource.Id.numberOfClicks);
			var numberOfMatches = FindViewById<TextView> (Resource.Id.numberOfMatches);

			Button diceButton = FindViewById<Button> (Resource.Id.diceButton);

			ISharedPreferences prefs = GetSharedPreferences (MDG_DATA, FileCreationMode.Private);
			ISharedPreferencesEditor editor = prefs.Edit ();
			//prefs.Edit ().Clear ().Apply ();

			//HashSet<String> categoryList = new HashSet<String> ();
			//
			numberResult.TextSize = 110;
			matchNumber.TextSize = 130;
			categoryText.TextSize = 25;
			titleText.TextSize = 27;

			categoryText.Text = "CATEGORY: 1-" + categoryMax;

			// Radio Buttons clicked
			diceButton.Click += delegate {
				int resultR = RandomNumber (1, categoryMax);
				numberResult.Text = resultR.ToString ();
				int resultM = RandomNumber (1, 36);
				matchNumber.Text = resultM.ToString();

				// See if it matches & display number of matches & accuracy
				if (resultR == resultM) {
					Toast.MakeText (this, "Awesome Stuff! It's a MATCH!", ToastLength.Long).Show();

					// Number of matches & accuracy calculation
					numberOfM += 1;
				}

				// Add total & display it
				total += resultR;
				totalScore.Text = "Total: " + total.ToString();	

				// Number of clicks counter
				numberOfC += 1;

				numberOfClicks.Text = "Number of Clicks: " + numberOfC.ToString();
				if(numberOfC != 0){ accuracy = (numberOfM/numberOfC)*100;}
				if(numberOfM == 0){ numberOfMatches.Text = "Number of Matches: 0" + "  -  " + "0%";}
				else{
					numberOfMatches.Text = "Number of Matches: " + numberOfM.ToString() + "  -  " + accuracy.ToString(".0##") + "%";
				}

				// Statistics for all categories in MDG
				if (categoryMax == 6) {	
					editor.PutInt("totalScoreSix", total);
					editor.PutFloat("numberOfClicksSix", numberOfC);
					editor.PutFloat("numberOfMathcesSix", numberOfM); }
				else if (categoryMax == 12) {	 
					editor.PutInt("totalScoreTwelve", total);
					editor.PutFloat("numberOfClicksTwelve", numberOfC);
					editor.PutFloat("numberOfMathcesTwelve", numberOfM); }
				else if (categoryMax == 18) {	 
					editor.PutInt("totalScoreEighteen", total);
					editor.PutFloat("numberOfClicksEighteen", numberOfC);
					editor.PutFloat("numberOfMathcesEighteen", numberOfM);}
				else if (categoryMax == 24) {	 
					editor.PutInt("totalScoreTwentyfour", total);
					editor.PutFloat("numberOfClicksTwentyfour", numberOfC);
					editor.PutFloat("numberOfMathcesTwentyfour", numberOfM);}
				else if (categoryMax == 30) {	
					editor.PutInt("totalScoreThirty", total);
					editor.PutFloat("numberOfClicksThirty", numberOfC);
					editor.PutFloat("numberOfMathcesThirty", numberOfM);}
				else if (categoryMax == 36) {	
					editor.PutInt("totalScoreThirtysix", total);
					editor.PutFloat("numberOfClicksThirtysix", numberOfC);
					editor.PutFloat("numberOfMathcesThirtysix", numberOfM);}
				editor.Apply ();
			};



			// Gesture Detection
			gestureDetector = new GestureDetector(this);
		}
			
		// Randomizer
		private int RandomNumber (int minRange, int maxRange){
			lock(syncLock) {
				return randomNum.Next(minRange, maxRange + 1);
			}
		}

		// Gestures
		public override bool OnTouchEvent(MotionEvent e)
		{
			gestureDetector.OnTouchEvent(e);
			return true;
		}
		public bool OnDown(MotionEvent e) {return true;}

		// Used for Swiping
		public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			float diffY = e2.GetY() - e1.GetY();
			float diffX = e2.GetX() - e1.GetX();

			if (Math.Abs(diffX) > Math.Abs(diffY))
			{
				if (Math.Abs(diffX) > SWIPE_THRESHOLD && Math.Abs(velocityX) > SWIPE_VELOCITY_THRESHOLD)
				{
					if (diffX > 0)
					{
						// Left Swipe - go back
						Intent slideIntent = new Intent(this, typeof(DiceCategoriesActivity));
						Bundle slideAnim = ActivityOptions.MakeCustomAnimation(Application.Context, Resource.Animation.Anim3, Resource.Animation.Anim4).ToBundle();
						StartActivity(slideIntent, slideAnim);
						Finish ();
					}
					else
					{
						// Right Swipe
					}
				}
			}
			else if (Math.Abs(diffY) > SWIPE_THRESHOLD && Math.Abs(velocityY) > SWIPE_VELOCITY_THRESHOLD)
			{
				if (diffY > 0)
				{
					// Top swipe
				}
				else
				{
					// Bottom swipe
				}
			}
			return true;
		}
		//
		public void OnLongPress(MotionEvent e) {}
		public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY) {return false;}
		public void OnShowPress(MotionEvent e) {}
		public bool OnSingleTapUp(MotionEvent e) {return false;}
	}
}