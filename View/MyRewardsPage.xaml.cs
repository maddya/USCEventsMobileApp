using System;
using System.Collections.Generic;
using USCEvents.Models;
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
			FirebaseService f = new FirebaseService();
			InitializeComponent();
			//rewards = rewardsService.GetRewards(); //dictionary of point values : rewards 
			//MyRewardsView.IsGroupingEnabled = true;
            var myrew = App.me.myRewards;
            MyRewardsView.ItemsSource = myrew;


		}



		//Select reward --> details page of that reward
		private void OnMyRewardSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem;
			Navigation.PushAsync(new MyRewardsDetailsPage((Reward)item));
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
