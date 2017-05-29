using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using USCEvents.Models;
using USCEvents.Services;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;
using USCEvents.View;

namespace USCEvents
{
	public partial class RewardsPage : ContentPage
	{
		//void Handle_Clicked(object sender, System.EventArgs e)
		//{
		//	throw new NotImplementedException();
		//}

		private Dictionary<int, List<Reward>> rewards { get; set; }
		//private ObservableCollection<Grouping<Reward>> RewardsGrouped { get; set; }
		private RewardsService rewardsService = new RewardsService();


		public RewardsPage()
		{
			InitializeComponent();
			rewards = rewardsService.GetRewards(); //dictionary of point values : rewards 
			
			RewardsView.IsGroupingEnabled = true;
			RewardsView.ItemsSource = rewards.Values;

		}

		//Select reward --> details page of that reward
		private void OnRewardSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem;
			Navigation.PushAsync(new RewardsDetailsPage((Reward)item));
		}

		//my rewards selected --> my rewards page
		private void OnMyRewardsClicked(object sender, EventArgs e)
		{
			//var item = e.SelectedItem;
			Navigation.PushAsync(new MyRewardsPage());
		}

		//Checkin selected --> check in page
		private void OnCheckinClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new CheckinLoadingPage());
		}

		public async void CheckIn_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CheckinLoadingPage());
		}

		public async void MyRewards_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MyRewardsPage());
		}
	}
}
