using System;
using System.Collections.Generic;
using USCEvents.Services;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class MyRewardsPage : ContentPage
	{
		public MyRewardsPage()
		{
			FirebaseService f = new FirebaseService();
			InitializeComponent();
		}
	}
}
