
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
	[Activity (Label = "CALDGActivity")]			
	public class CALDGActivity : Activity
	{
		public static String CALDG_DATA = "CALDGData";

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			ScrollView scrollView = new ScrollView (this);
			TextView CALDGStatsView = new TextView (this);
			scrollView.AddView (CALDGStatsView);

			SetContentView (scrollView);

			ISharedPreferences CALDGPref = GetSharedPreferences (CALDG_DATA, FileCreationMode.Private);
			ISharedPreferencesEditor CALDGEditor = CALDGPref.Edit ();

			String userInputOne = CALDGPref.GetString ("CALDGStatsString0", String.Empty);
			String latestAmountOne = CALDGPref.GetString ("CALDGStatsString1", String.Empty);
			String latestBetOne = CALDGPref.GetString ("CALDGStatsString2", String.Empty);
			String totalLostOne = CALDGPref.GetString ("CALDGStatsString3", String.Empty);
			String totalWonOne = CALDGPref.GetString ("CALDGStatsString4", String.Empty);
			String totalMatchesOne = CALDGPref.GetString ("CALDGStatsString5", String.Empty);

			String userInputTwo = CALDGPref.GetString ("CALDGStatsString6", String.Empty);
			String latestAmountTwo = CALDGPref.GetString ("CALDGStatsString7", String.Empty);
			String latestBetTwo = CALDGPref.GetString ("CALDGStatsString8", String.Empty);
			String totalLostTwo = CALDGPref.GetString ("CALDGStatsString9", String.Empty);
			String totalWonTwo = CALDGPref.GetString ("CALDGStatsString10", String.Empty);
			String totalMatchesTwo = CALDGPref.GetString ("CALDGStatsString11", String.Empty);

			String userInputThree = CALDGPref.GetString ("CALDGStatsString12", String.Empty);
			String latestAmountThree = CALDGPref.GetString ("CALDGStatsString13", String.Empty);
			String latestBetThree = CALDGPref.GetString ("CALDGStatsString14", String.Empty);
			String totalLostThree = CALDGPref.GetString ("CALDGStatsString15", String.Empty);
			String totalWonThree = CALDGPref.GetString ("CALDGStatsString16", String.Empty);
			String totalMatchesThree = CALDGPref.GetString ("CALDGStatsString17", String.Empty);

			String userInputFour = CALDGPref.GetString ("CALDGStatsString18", String.Empty);
			String latestAmountFour = CALDGPref.GetString ("CALDGStatsString19", String.Empty);
			String latestBetFour = CALDGPref.GetString ("CALDGStatsString20", String.Empty);
			String totalLostFour = CALDGPref.GetString ("CALDGStatsString21", String.Empty);
			String totalWonFour = CALDGPref.GetString ("CALDGStatsString22", String.Empty);
			String totalMatchesFour = CALDGPref.GetString ("CALDGStatsString23", String.Empty);

			String userInputFive = CALDGPref.GetString ("CALDGStatsString24", String.Empty);
			String latestAmountFive = CALDGPref.GetString ("CALDGStatsString25", String.Empty);
			String latestBetFive = CALDGPref.GetString ("CALDGStatsString26", String.Empty);
			String totalLostFive = CALDGPref.GetString ("CALDGStatsString27", String.Empty);
			String totalWonFive = CALDGPref.GetString ("CALDGStatsString28", String.Empty);
			String totalMatchesFive = CALDGPref.GetString ("CALDGStatsString29", String.Empty);

			String userInputSix = CALDGPref.GetString ("CALDGStatsString30", String.Empty);
			String latestAmountSix = CALDGPref.GetString ("CALDGStatsString31", String.Empty);
			String latestBetSix = CALDGPref.GetString ("CALDGStatsString32", String.Empty);
			String totalLostSix = CALDGPref.GetString ("CALDGStatsString33", String.Empty);
			String totalWonSix = CALDGPref.GetString ("CALDGStatsString34", String.Empty);
			String totalMatchesSix = CALDGPref.GetString ("CALDGStatsString35", String.Empty);

			CALDGStatsView.Text = "LATEST GAME SCORES:\n" +
			"User Input: " + userInputOne + "\n" +
			"Latest Amount: " + latestAmountOne + "\n" +
			"Latest Bet: " + latestBetOne + "\n" +
			"Total Lost: " + totalLostOne + "\n" +
			"Total Won: " + totalWonOne + "\n" +
			"Total Matches: " + totalMatchesOne + "\n\n" +

			"User Input: " + userInputTwo + "\n" +
			"Latest Amount: " + latestAmountTwo + "\n" +
			"Latest Bet: " + latestBetTwo + "\n" +
			"Total Lost: " + totalLostTwo + "\n" +
			"Total Won: " + totalWonTwo + "\n" +
			"Total Matches: " + totalMatchesTwo + "\n\n" +

			"User Input: " + userInputThree + "\n" +
			"Latest Amount: " + latestAmountThree + "\n" +
			"Latest Bet: " + latestBetThree + "\n" +
			"Total Lost: " + totalLostThree + "\n" +
			"Total Won: " + totalWonThree + "\n" +
			"Total Matches: " + totalMatchesThree + "\n\n" +

			"User Input: " + userInputFour + "\n" +
			"Latest Amount: " + latestAmountFour + "\n" +
			"Latest Bet: " + latestBetFour + "\n" +
			"Total Lost: " + totalLostFour + "\n" +
			"Total Won: " + totalWonFour + "\n" +
			"Total Matches: " + totalMatchesFour + "\n\n" +

			"User Input: " + userInputFive + "\n" +
			"Latest Amount: " + latestAmountFive + "\n" +
			"Latest Bet: " + latestBetFive + "\n" +
			"Total Lost: " + totalLostFive + "\n" +
			"Total Won: " + totalWonFive + "\n" +
			"Total Matches: " + totalMatchesFive + "\n\n" +

			"User Input: " + userInputSix + "\n" +
			"Latest Amount: " + latestAmountSix + "\n" +
			"Latest Bet: " + latestBetSix + "\n" +
			"Total Lost: " + totalLostSix + "\n" +
			"Total Won: " + totalWonSix + "\n" +
			"Total Matches: " + totalMatchesSix + "\n";

		}
	}
}

