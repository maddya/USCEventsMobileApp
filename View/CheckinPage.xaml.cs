using System;
using System.Collections.Generic;
using USCEvents.Models;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class CheckInPage : ContentPage
	{
		public CheckInPage(Event e)
		{
			InitializeComponent();
			Dismiss.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => OnDismiss()),
			});
			Dismiss_Label.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => OnDismiss()),
			});
            YourPts.Text = "You now have " + App.me.Points + " points";
            Success.Text = "You successfully checked into this event for " + e.Points + " points! The points have been added to your accout.";
		}

		private void OnDismiss()
		{
			Navigation.PopAsync();
		}


	}
}
