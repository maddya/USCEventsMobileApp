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
			terms.Text = "VIEW TERMS & CONDITIONS";
			privacy.Text = "VIEW PRIVACY POLICY";
			accept.Text = "I ACCEPT";

			// Make terms clickable
			terms_box.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command(() => Terms_Clicked()),
			});
			terms.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command(() => Terms_Clicked()),
			});

			// Make privacy clickable
			privacy_box.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command(() => Privacy_Clicked()),
			});
			privacy.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command(() => Privacy_Clicked()),
			});

			// Make accept clickable
			accept_box.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command(() => Accept_Clicked()),
			});
			accept.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command(() => Accept_Clicked()),
			});
		}

		async void Terms_Clicked()
		{
			await Navigation.PushAsync(new TermsPage());
		}

		async void Privacy_Clicked()
		{
			await Navigation.PushAsync(new PrivacyPage());
		}

		async void Accept_Clicked()
		{
			//MainPage = new USCEventsPage();
			App.loginComplete = true;
			await Navigation.PushModalAsync(new USCEventsPage());
		}
	}
}
