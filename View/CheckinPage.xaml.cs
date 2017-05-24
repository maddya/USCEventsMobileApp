using System;
using System.Collections.Generic;
using USCEvents.Models;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class CheckinPage : ContentPage
	{
		public CheckinPage(Event e)
        {
			InitializeComponent();
			Dismiss.GestureRecognizers.Add (new TapGestureRecognizer {
			    Command = new Command(() => OnDismiss()),
			});
			Dismiss_Label.GestureRecognizers.Add (new TapGestureRecognizer {
			    Command = new Command(() => OnDismiss()),
			});

            checkedinlabel.Text = "You successfully checked into " + e.Title + " for " + e.Points + " points!";
		}

		private void OnDismiss()
		{
			Navigation.PopAsync();
		}


	}
}
