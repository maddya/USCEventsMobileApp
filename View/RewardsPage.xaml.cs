using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using USCEvents.Models;
using USCEvents.Services;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class RewardsPage : ContentPage
	{

		private List<Reward> rewards { get; set; }
		private RewardsService rewardsService = new RewardsService();

		public RewardsPage()
		{
			InitializeComponent();
			rewards = rewardsService.GetRewards();
			RewardsView.ItemsSource = rewards;
		}

		private void OnRewardSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem;
			Navigation.PushAsync(new RewardsDetailsPage((Reward)item));
		}
	}
}
