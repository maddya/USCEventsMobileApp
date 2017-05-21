using System;
using System.Collections.Generic;
using USCEvents.Services;
using USCEvents.View;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class MyRewardsPage : ContentPage
	{

		private Dictionary<int, List<Reward>> rewards { get; set; }
		//private ObservableCollection<Grouping<Reward>> RewardsGrouped { get; set; }
		private RewardsService rewardsService = new RewardsService();

		public MyRewardsPage()
		{
			InitializeComponent();
			rewards = rewardsService.GetRewards(); //dictionary of point values : rewards 
			MyRewardsView.IsGroupingEnabled = true;
			MyRewardsView.ItemsSource = rewards.Values;
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
	}
}
