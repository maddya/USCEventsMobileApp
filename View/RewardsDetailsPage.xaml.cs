using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using USCEvents.Models;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class RewardsDetailsPage : ContentPage
	{
		//public Reward rew { get; private set; }
		//private ObservableCollection<Reward> rewar { get; set; }

		public RewardsDetailsPage(Reward r)
		{
			InitializeComponent();
			//title.Text = r.Title;
			description.Text = r.Description;
			img.Source = r.RewardsImage;
			btn.Text = "Confirm Reward for " + r.Points + " Points";
			//btn.Clicked = "OnRedeem";
		}
		private void OnRedeem(object sender, EventArgs e)
		{
			//var item = e.SelectedItem;
			//await Navigation.PushAsync(profileDetailPage);
			Debug.WriteLine("Confirming redeem");
            DisplayAlert("Alert", "You have been alerted", "OK", "Cancel");
		}
	}           
}

