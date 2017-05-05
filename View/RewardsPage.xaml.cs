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

		private ObservableCollection<Reward> rewards { get; set; }
		//private ObservableCollection<Grouping<Reward>> RewardsGrouped { get; set; }
		private RewardsService rewardsService = new RewardsService();


		public RewardsPage()
		{
			InitializeComponent();
			rewards = rewardsService.GetRewards();
			//Use linq to sorty our monkeys by name and then group them by the new name sort property
			//var sorted = from Reward in rewards
			//			 orderby Reward.Points
			//			 group Reward by Reward.Points into rewardsGroup
			//			 select new Grouping<Reward>(rewardsGroup);

			//////create a new collection of groups
			//RewardsGrouped = new ObservableCollection<Grouping<Reward>>(sorted);


			RewardsView.ItemsSource = rewards;
		}
	

		private void OnRewardSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem;
			Navigation.PushAsync(new RewardsDetailsPage((Reward)item));
		}
	}
}
