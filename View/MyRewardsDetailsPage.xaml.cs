using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using USCEvents.Models;
using USCEvents.Services;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class MyRewardsDetailsPage : ContentPage
	{
		public MyRewardsDetailsPage(Reward r)
		{
			InitializeComponent();
            if(r.isRedeemed){
				confirm_box.HeightRequest = 100;
				redeem.Text = "REWARD HAS ALREADY BEEN REDEEMED";
            }
            else{
				redeem.Text = "REDEEM " + r.Title.ToUpper();
				confirm_box.GestureRecognizers.Add(new TapGestureRecognizer
				{
					Command = new Command(() => OnRedeem(r)),
				});
				redeem.GestureRecognizers.Add(new TapGestureRecognizer
				{
					Command = new Command(() => OnRedeem(r)),
				});
            }
			
			//title.Text = r.Title.ToUpper();
			image.Source = r.RewardsImage;
			//image.Aspect = Aspect.AspectFit;
			description.Text = r.Description;
			//label.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnLabelClicked()));

			//make the "confirm" button clickable
			
		}

        //called if the user accepts the button to view voucher (should be done at merch desk)
		async void OnRedeem(Reward r)
		{
            var f = new FirebaseService();
            var confirm = await DisplayAlert("Redeeem Voucher", "Once redeemed, voucher will no longer be available, please hand to Merch booth to redeem.", "REDEEM", "CANCEL");
            //if user selects confirm, call onredeem
            if (confirm) {
                //remove locally

                App.me.myRewards.Remove(r);
                r.isRedeemed = true;
                //var m = App.me;
                App.me.myRewards.Add(r);

				await f.UpdateRewards();

				//await Navigation.PopAsync();

                await Navigation.PushAsync(new MyRewardsPage());
            }

		}

		//confirm redeeming points - need to send points and reward redeemed
		private async void OnRedeemConfirmed(Reward r)
		{
			FirebaseService f = new FirebaseService();
			await f.AddReward(App.me, r);
			await Navigation.PushAsync(new RedeemConfirmationPage((Reward)r));
			App.me.Points = App.me.Points - r.Points;
			//need to also send redemption and put them on list
		}
	}
}



