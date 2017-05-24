using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

	public partial class FacebookPage : ContentPage
	{
		public static string LOGIN_COMPLETE = "login_complete";
		private string appID = "1338914686200042";

		public FacebookPage()
		{
			InitializeComponent();
			var apiRequest =
				"https://www.facebook.com/dialog/oauth?client_id="
				+ appID
				+ "&scope=public_profile"
				+ "&response_type=token"
				+ "&redirect_uri=https://www.facebook.com/connect/login_success.html";

			var webView = new WebView
			{
				Source = apiRequest,
				HeightRequest = 1
			};

			webView.Navigated += WebView_Navigated;

			Content = webView;
		}

		async void WebView_Navigated(object sender, WebNavigatedEventArgs e)
		{
			var accessToken = ExtractAccessTokenFromUrl(e.Url);

			if (accessToken != "")
			{
				App.accessToken = accessToken;

				MessagingCenter.Send<FacebookPage, string>(this, FacebookPage.LOGIN_COMPLETE, accessToken);

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
					at = url.Replace("http://www.facebook.com/connect/login_success.html#access_token=", "");
				}

				var accessToken = at.Remove(at.IndexOf("&expires_in="));

				return accessToken;
			}

			return string.Empty;
		}

	}
}
