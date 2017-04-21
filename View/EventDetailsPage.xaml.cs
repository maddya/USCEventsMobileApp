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
			description.Text = "That other text? Sadly, it’s no longer a 10. You have so many different things placeholder text has to be able to do, and I don't believe Lorem Ipsum has the stamina. All of the words in Lorem Ipsum have flirted with me - consciously or unconsciously. That's to be expected. I have a 10 year old son. He has words. He is so good with these words it's unbelievable.";
			//description.Text = e.Description;
		}
	}
}
