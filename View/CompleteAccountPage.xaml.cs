using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using USCEvents.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class CompleteAccountPage : ContentPage
	{
		public CompleteAccountPage()
		{
			InitializeComponent();

			//name.Text = facebookProfile.Name;
			//profileImage.Source = facebookProfile.Picture.Data.Url;
		}

		async void Terms_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new TermsPage());
		}

		async void Privacy_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new PrivacyPage());
		}

		async void Accept_Clicked(object sender, System.EventArgs e)
		{
			//MainPage = new USCEventsPage();
			App.loginComplete = true;
			await Navigation.PushModalAsync(new USCEventsPage());
		}
	}
}
