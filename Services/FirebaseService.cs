using System;
using Firebase.Xamarin.Auth;
using Firebase.Xamarin.Database;
using USCEvents.Models;

namespace USCEvents.Services
{
	public class FirebaseService
	{

		private FirebaseClient firebase { get; set; }
		private FirebaseAuthProvider authProvider { get; set; }
		private FirebaseAuthLink auth { get; set; }


        public FirebaseService()
        {
            firebase = new FirebaseClient("https://usceventsapp.firebaseio.com/");
        }

		
        public async void PostUserEventUpgrade(UserEventUpgrade eventUpgrade) {
			var item = await firebase
                .Child(eventUpgrade.EventName + " " + eventUpgrade.EventYear)
                .PostAsync(eventUpgrade, false);
        }

        public async void PostUserEventReward(UserRewardItem rewardItem) {
			var item = await firebase
				.Child("Reward Items")
                .PostAsync(rewardItem, false);
        }


		public async void AddNewUser(Models.User user)
		{
			var item = await firebase
				.Child("Users")
				.PostAsync(user, false);
		}

        // this is the method I'm currently using in MyRewardsPage.xaml.cs
        // the refactored methods are above and what we're eventually gonna use, I just haven't implemented yet
        public async void PostData()
		{
			// add new item to list of data 
			var item = await firebase
				.Child("Life in Color 2017")
				//.WithAuth("<Authentication Token>") // <-- Add Auth token if required. Auth instructions further down in readme.
				.PostAsync(new UserEventUpgrade
				{
					LegalUserName = "Madeleine Austin",
				}, false);
		}
	}
}
