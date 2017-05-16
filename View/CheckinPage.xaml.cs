using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace USCEvents
{
	public partial class CheckinPage : ContentPage
	{
		public CheckinPage()
		{
			InitializeComponent();
			Dismiss.GestureRecognizers.Add (new TapGestureRecognizer {
			    Command = new Command(() => OnDismiss()),
			});
			Dismiss_Label.GestureRecognizers.Add (new TapGestureRecognizer {
			    Command = new Command(() => OnDismiss()),
			});
		}

		private void OnDismiss()
		{
			Navigation.PopAsync();
		}


	}
}
