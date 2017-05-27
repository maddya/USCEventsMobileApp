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
		}

		private void OnDismiss()
		{
			Navigation.PopAsync();
		}


	}
}
