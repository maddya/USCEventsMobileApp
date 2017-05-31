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
        private List<Reward> fifty_pts;
        private List<Reward> hundred_pts;
        private List<Reward> one_fifty_pts;


		public RewardsPage()
		{
			InitializeComponent();
            NavigationPage.SetTitleIcon(this, "USCBlack.png");
			rewards = rewardsService.GetRewards(); //dictionary of point values : rewards 
            fifty_pts = rewards[50];
            hundred_pts = rewards[100];
            one_fifty_pts = rewards[150];


            fifty_points_view.ItemsSource = fifty_pts;
            hundred_points_view.ItemsSource = hundred_pts;
            one_fifty_points_view.ItemsSource = one_fifty_pts;

            fifty_points_view.ItemTapped += async (sender, e) =>
	        {
	            await Navigation.PushAsync(new RewardsDetailsPage(e.Item as Reward));
			    ((ListView)sender).SelectedItem = null;
	        };

            hundred_points_view.ItemTapped += async (sender, e) =>
			{
				await Navigation.PushAsync(new RewardsDetailsPage(e.Item as Reward));
				((ListView)sender).SelectedItem = null;
			};

            one_fifty_points_view.ItemTapped += async (sender, e) =>
			{
				await Navigation.PushAsync(new RewardsDetailsPage(e.Item as Reward));
				((ListView)sender).SelectedItem = null;
			};
			//RewardsView.IsGroupingEnabled = true;
			//RewardsView.ItemsSource = rewards.Values;

		}

		////Select reward --> details page of that reward
		//private async void OnRewardSelected(object sender, SelectedItemChangedEventArgs e)
		//{
		//	var item = e.SelectedItem;
  //          Reward temp = new Reward((Reward)item);
		//	await Navigation.PushAsync(new RewardsDetailsPage((Reward)item));
		//}

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
