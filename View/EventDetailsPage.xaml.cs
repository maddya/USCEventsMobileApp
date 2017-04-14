using System;
using System.Collections.Generic;
using USCEvents.Models;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class EventDetailsPage : ContentPage
	{
		public EventDetailsPage(Event e)
		{
			InitializeComponent();
			title.Text = e.Title;
			venue.Text = e.Venue;
			venueAddress.Text = e.VenueAdress;
			time.Text = e.StartDateAndTime + " to " + e.EndDateAndTime;
			description.Text = e.Description;
		}
	}
}
