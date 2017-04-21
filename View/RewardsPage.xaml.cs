using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace USCEvents
{
	public partial class RewardsPage : ContentPage
	{
		public RewardsPage()
		{
			InitializeComponent();
		}

		public async void CheckIn_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CheckInPage());
		}

		public async void MyRewards_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MyRewardsPage());
		}
	}
}
