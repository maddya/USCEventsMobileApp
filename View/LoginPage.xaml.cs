﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using USCEvents.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		async void Login_Clicked(object sender, System.EventArgs e)
		{
			MessagingCenter.Subscribe<FacebookPage, string>(this, FacebookPage.LOGIN_COMPLETE, HandleAction);

			await Navigation.PushModalAsync(new FacebookPage());
		}

		async void HandleAction(USCEvents.FacebookPage arg1, string accessToken)
		{
			App.accessToken = accessToken;

			var facebookProfile = await GetFacebookProfileAsync(accessToken);

			await Navigation.PushAsync(new CompleteAccountPage());
		}

		public async Task<UserInfo> GetFacebookProfileAsync(string accessToken)
		{
			var requestUrl =
				"https://graph.facebook.com/v2.8/me/?fields=id,name,gender,email,link,picture&access_token="
				+ accessToken;

			var httpClient = new HttpClient();

			var userJson = await httpClient.GetStringAsync(requestUrl);

			var facebookProfile = JsonConvert.DeserializeObject<UserInfo>(userJson);

			//App.myName = facebookProfile.Name;
			App.me = facebookProfile;

			return facebookProfile;
		}
	}
}
