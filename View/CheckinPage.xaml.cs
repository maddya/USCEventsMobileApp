using System;
using System.Collections.Generic;
using USCEvents.Models;
using Xamarin.Forms;

namespace USCEvents.View
{
	public partial class CheckInPage : ContentPage
	{
		public CheckInPage(Event e)
		{
			InitializeComponent();

            MessageTitle.Text = "You got " + e.Points + " points!";
            MessageDetails.Text = "You successfully checked into this event for " + e.Points + " points! The points have been added to your accout.";
            MessageCurrentPoints.Text = "You now have " + App.me.Points + " points";
                
			Dismiss.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => OnDismiss()),
			});
			Dismiss_Label.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => OnDismiss()),
			});
		}

		private void OnDismiss()
		{
			Navigation.PopAsync();
		}


	}
}
