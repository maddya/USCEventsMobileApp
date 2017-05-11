using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using USCEvents.Models;
using USCEvents.Services;
using Xamarin.Forms;
using System.Linq;

namespace USCEvents
{
	public partial class RewardsPage : ContentPage
	{
		//void Handle_Clicked(object sender, System.EventArgs e)
		//{
		//	throw new NotImplementedException();
		//}

		private ObservableCollection<Reward> rewards { get; set; }
		//private ObservableCollection<Grouping<Reward>> RewardsGrouped { get; set; }
		private RewardsService rewardsService = new RewardsService();


		public RewardsPage()
		{
			InitializeComponent();
			rewards = rewardsService.GetRewards();


			RewardsView.ItemsSource = rewards;
			//CheckinButton.Clicked += OnCheckinClicked;
			//My_rew.Clicked += OnMyRewardsClicked;

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
			Navigation.PushAsync(new CheckinPage());
		}
	}
}
