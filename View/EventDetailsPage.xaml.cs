using System;
using System.Collections.Generic;
using System.Globalization;
using USCEvents.Models;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class EventDetailsPage : ContentPage
	{
		public EventDetailsPage(Event e)
		{
			InitializeComponent();
			title.Text = e.Title.ToUpper();
			venue.Text = e.Venue.ToUpper();
			var day = e.StartDateAndTime.DayOfWeek.ToString();
			var calendarDate = e.StartDateAndTime.Date.ToString("MMMM dd, yyyy");
			date.Text = day + " " + calendarDate;
			time.Text = e.StartDateAndTime.ToString("t");
			//venueAddress.Text = e.VenueAdress;
			//startDateAndTime.Text = e.StartDateAndTime;
			image.Source = e.EventImageSource;
			image.Aspect = Aspect.AspectFit;
            description.Text = e.Description;
			//description.Text = e.Description;
		}
	}
}