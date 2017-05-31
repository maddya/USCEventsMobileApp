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

        public async Task<string> UpdateUser()
        {
            await firebase
                .Child("Users/" + App.me.Id)
                .DeleteAsync();
            var item = await firebase
                .Child("Users/" + App.me.Id)
                .PostAsync(App.me, false);
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

        //add a reward to the ID for a particular user (local user) on firebase
        public async Task<String> AddReward(UserInfo user, Reward reward) {
            var item = await firebase
                .Child("Rewards/" + user.Id)
                .PostAsync(reward);
            App.me.Points = App.me.Points - reward.Points; //set new points
            return item.Key;
            //need to push new points to firebase...
        }

        //Will read the users rewards from firebase
		public async Task<FirebaseObject<Reward>> ReadRewardData(string ID)
		{
            //App.me.myRewards = new List<Reward>();
			var items = await firebase
				.Child("Rewards/"+ID)
				.OnceAsync<Reward>();
            App.me.myRewards = new List<Reward>();
			foreach (var user in items)
			{
                
                var rew = user.Object;
				App.me.myRewards.Add(rew);
                //return user;
			}
			return null;
		}

		public async Task<FirebaseObject<Reward>> UpdateRewards()
		{
            //clear current rewards
			await firebase
				.Child("Rewards/" + App.me.Id)
				.DeleteAsync();
            foreach (Reward r in App.me.myRewards){
				var item = await firebase
				.Child("Rewards/" + App.me.Id)
				.PostAsync(r, false);
            }
            return null;
		}
	}
}
