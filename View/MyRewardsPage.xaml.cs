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
        private RewardsService rewardsService = new RewardsService();
        private List<Reward> myRewards = App.me.myRewards;

        private List<Reward> Available { get; set;}
        private List<Reward> Redeemed { get; set; }

		public MyRewardsPage()
		{
            InitializeComponent();
			FirebaseService f = new FirebaseService();

            Redeemed = getRedeemed();
            Available = getAvailable();

            MyAvailable.ItemsSource = Available;
            MyRedeemed.ItemsSource = Redeemed;

		}

        private List<Reward> getRedeemed()
        {
            List<Reward> redeem = new List<Reward>();
            foreach (Reward r in myRewards)
            {
                if (r.isRedeemed)
                {
                    redeem.Add(r);
                }
            }
            return redeem;
        }

		private List<Reward> getAvailable()
		{
			List<Reward> avail = new List<Reward>();
			foreach (Reward r in myRewards)
			{
				if (!r.isRedeemed)
				{
					avail.Add(r);
				}
			}
			return avail;
		}

		//Select reward --> details page of that reward
		private void OnMyRewardSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem;
            var r = (Reward)item;
            Navigation.PushAsync(new MyRewardsDetailsPage(r));
			
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
