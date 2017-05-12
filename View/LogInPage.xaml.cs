﻿using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;
using USCEvents.Models;
using USCEvents.Services;
using Xamarin.Forms;

namespace USCEvents
{
	public class FacebookInformation
	{
		public string range { get; set; }
		public string majorDimension { get; set; }
		public List<List<string>> values { get; set; }	
	}

	public partial class LogInPage : ContentPage
	{
		private String ClientID = "1338914686200042";
		public static string LOGIN_COMPLETE = "login_complete";

		public LogInPage()
		{
			InitializeComponent();

			var apiRequest =
				"https://www.facebook.com/v2.9/dialog/oauth?"
				+ "client_id=" + ClientID
				+ "&response_type=token"
				+ "&redirect_uri=" + "https://www.facebook.com/connect/login_success.html";

			var webView = new WebView
			{
				Source = apiRequest,
				HeightRequest = 1
			};

			webView.Navigated += WebViewOnNavigated;

			Content = webView;
		}

		private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
		{
			var accessToken = ExtractAccessTokenFromUrl(e.Url);

			if (accessToken != "")
			{
				//await GetFacebookProfileAsync(accessToken);

				App.accessToken = accessToken;
				MessagingCenter.Send<LogInPage, string>(this, LogInPage.LOGIN_COMPLETE, accessToken);
				await Navigation.PopModalAsync();
			}
		}

		private string ExtractAccessTokenFromUrl(string url)
		{
			if (url.Contains("access_token") && url.Contains("&expires_in="))
			{
				var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

				if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
				{
					at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");
				}

				var accessToken = at.Remove(at.IndexOf("&expires_in="));

				return accessToken;
			}

			return string.Empty;
		}

		public async Task<FacebookInformation> GetFacebookProfileAsync(string accessToken)
		{
			var requestURL =
				"https://graph.facebook.com/v2.7/me/"
				+ "?fields=name,email" // THIS IS WHERE YOU WOULD GET GENDER/PIC/VERIFIED/OTHER INFO
				+ "&access_token=" + accessToken;

			var httpClient = new HttpClient();

			var userJSON = await httpClient.GetStringAsync(requestURL);

			var facebookInformation = JsonConvert.DeserializeObject<FacebookInformation>(userJSON);

			return facebookInformation;
		}
	}
}
