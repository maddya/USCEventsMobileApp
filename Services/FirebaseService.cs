using System;
using Firebase.Xamarin.Auth;
using Firebase.Xamarin.Database;

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
			// Email/Password Auth
			//authProvider = new FirebaseAuthProvider(new FirebaseConfig("<google.firebase.com AIzaSyBbum5sii-g--X0KAQ9lOWjb2Ntu6JchkE>"));
			//GetAuth();
		}

		//private async void GetAuth()
		//{
		//	auth = await authProvider.CreateUserWithEmailAndPasswordAsync("maddyaustin55@gmail.com", "password");
		//}

		public async void postData()
		{
			// add new item to list of data 
			var item = await firebase
				.Child("usceventsapp")
			  	//.WithAuth("<Authentication Token>") // <-- Add Auth token if required. Auth instructions further down in readme.
				.PostAsync(new UserEventReward
				{
					LegalUserName = "Madeleine Austin",
					EventName = "Life in Color",
					EventYear = "2017"
				}, false);

			// note that there is another overload for the PostAsync method which delegates the new key generation to the client

			//Console.WriteLine($"Key for the new item: {item.Key}");  

			//// add new item directly to the specified location (this will overwrite whatever data already exists at that location)
			//var item = await firebase
			//  .Child("yourentity")
			//  .Child("Ricardo")
			//  //.WithAuth("<Authentication Token>") // <-- Add Auth token if required. Auth instructions further down in readme.
			//  .PutAsync(new YourObject());
		}
	}
}
