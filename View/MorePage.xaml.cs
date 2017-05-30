using System;
using System.Collections.Generic;
using USCEvents.View;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class MorePage : ContentPage
	{
		public MorePage()
		{
			InitializeComponent();
		}

		public async void Notifications_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NotificationsPage());
		}

		public async void Account_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AccountPage());
		}

		public async void Contact_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ContactPage());
		}

		public async void ConsciousCrew_Clicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new ConsciousCrewPage());
		}
	}
}