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
			redeem.Text = "Redeem for " + r.Points + " Points";
			//title.Text = r.Title.ToUpper();
			image.Source = r.RewardsImage;
			//image.Aspect = Aspect.AspectFit;
			//description.Text = "That other text? Sadly, it’s no longer a 10. You have so many different things placeholder text has to be able to do, and I don't believe Lorem Ipsum has the stamina. All of the words in Lorem Ipsum have flirted with me - consciously or unconsciously. That's to be expected. I have a 10 year old son. He has words. He is so good with these words it's unbelievable.";
			description.Text = r.Description;
			//label.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnLabelClicked()));

			//make the "confirm" button clickable
			confirm_box.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => OnRedeem(r)),
			});
			redeem.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => OnRedeem(r)),
			});
		}

        //called if the user accepts the button to view voucher (should be done at merch desk)
		async void OnRedeem(Reward r)
		{
            var f = new FirebaseService();
            var confirm = await DisplayAlert("Redeeem Voucher", "Once redeemed, voucher will no longer be available, please hand to Merch booth to redeem.", "REDEEM", "Cancel");
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



