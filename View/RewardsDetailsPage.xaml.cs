using System;
using System.Collections.Generic;
using USCEvents.Models;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class RewardsDetailsPage : ContentPage
	{
		public RewardsDetailsPage(Reward r)
		{
			InitializeComponent();
			//img.Text = r.RewardsImage;
			title.Text = r.Title;
			desc.Text = r.Description;
			//point.Text = r.Points;
		}
	}
}
