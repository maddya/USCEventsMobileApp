using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
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

        public async Task<string> AddNewUser(UserInfo user)
		{
			var item = await firebase
                .Child("Users/"+user.Id)
				.PostAsync(user, false);
            return item.Key;
		}

        public async Task<FirebaseObject<UserInfo>> ReadExistingUserData(string ID) {
            var items = await firebase
                .Child("Users/"+ID)
                .OnceAsync<UserInfo>();
            foreach (var user in items) {
                return user;
            }
            return null;
        }

        public async void AddReward(UserInfo user, Reward reward) {
            var item = await firebase
                .Child("Rewards/" + user.Id)
                .PostAsync(reward);
        }
	}
}
