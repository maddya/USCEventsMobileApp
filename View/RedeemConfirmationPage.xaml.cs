using System;
using System.Collections.Generic;
using USCEvents.Models;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class RedeemConfirmationPage : ContentPage
	{
		public RedeemConfirmationPage(Reward r)
		{
			InitializeComponent();
			image.Source = r.RewardsImage;
			rew_description.Text = "Congrats on redeeming " + r.Points + " points for " + r.Title + "!";
			curPoints.Text = "You now have " + r.Points + " Points!"; //needs to be changed to USERS points not REWARDS pointszepli

			ViewMyRew.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command(() => OnMyRewardsClicked()),
			});
			ViewRew.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command(() => OnMyRewardsClicked()),
			});

		}

		//my rewards selected --> my rewards page
		private void OnMyRewardsClicked()
		{
			//var item = e.SelectedItem;
			Navigation.PushAsync(new MyRewardsPage());
		}
	}
}
