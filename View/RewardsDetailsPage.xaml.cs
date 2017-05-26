using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using USCEvents.Models;
using USCEvents.Services;
using Xamarin.Forms;


namespace USCEvents
{
	public partial class RewardsDetailsPage : ContentPage
	{
		public RewardsDetailsPage(Reward r)
		{
			InitializeComponent();
			confirm.Text = "Redeem for " + r.Points + " Points";
			//title.Text = r.Title.ToUpper();
			image.Source = r.RewardsImage;
			//image.Aspect = Aspect.AspectFit;
			//description.Text = "That other text? Sadly, it’s no longer a 10. You have so many different things placeholder text has to be able to do, and I don't believe Lorem Ipsum has the stamina. All of the words in Lorem Ipsum have flirted with me - consciously or unconsciously. That's to be expected. I have a 10 year old son. He has words. He is so good with these words it's unbelievable.";
			description.Text = r.Description;
			//label.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnLabelClicked()));

			//make the "confirm" button clickable
			confirm_box.GestureRecognizers.Add (new TapGestureRecognizer {
			    Command = new Command (()=> OnRedeem(r)),
			});
			confirm.GestureRecognizers.Add (new TapGestureRecognizer {
			    Command = new Command(() => OnRedeem(r)),
			});
		}

        private bool canAfford(Reward r) {
            return App.me.Points >= r.Points;
        }

		async void OnRedeem(Reward r)
		{
            var afford = canAfford(r);
            //send true if redeem, false if cancel
            if (afford)
            {
			    var redeem_answer = await DisplayAlert("Alert", "Do you want to purchase " +r.Title+ " for " + r.Points+" points?", "Purchase", "Cancel");
                if (redeem_answer)
                {
                    OnRedeemConfirmed(r);
                }
            }
            else 
            {
                var alert = await DisplayAlert("Insufficient Points", "You do not have enough points to purchase this reward", null, "OK");
				 //if user selects confirm, call onredeem
			}
				
		}

		//confirm redeeming points - need to send points and reward redeemed
		private async void OnRedeemConfirmed(Reward r)
		{
            FirebaseService f = new FirebaseService();
            await f.AddReward(App.me, r);
            App.me.myRewards.Add(r);
            await Navigation.PushAsync(new RedeemConfirmationPage((Reward)r));
            App.me.Points = App.me.Points - r.Points;
            await f.UpdateUser();
            //need to also send redemption and put them on list

		}
	}
}


