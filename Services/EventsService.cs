using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using USCEvents.Models;

namespace USCEvents.Services
{
	public class EventsService
	{
		public const string Domain = "http://ourdomain.com/";

		public List<Event> GetEvents()
		{
			// This is where we would make an API call, and get back JSON data
			// then we would format that data, and return it as a list of Events
			var events = new List<Event>();
			events.Add(new Event { Title = "Bass Academy", 
				Venue = "Tacoma Dome",
				VenueAdress = "2727 E D St Tacoma, WA",
				Description = "Some heavy bass at the academy.",
				StartDateAndTime = "8/17/2017 9:00PM",
				EndDateAndTime = "8/18/2017 2:00AM",
				VenueAndDate = "Tacoma Dome - 8/17/2017"});
			events.Add(new Event { Title = "Life in Color",
				Venue = "Washington Mutual",
				VenueAdress = "800 Occidental Ave S Seattle, WA",
				Description = "Their life is in color, believe it or not.",
				StartDateAndTime = "9/10/2017 9:30PM",
				EndDateAndTime = "9/11/2017 2:00AM",
				VenueAndDate = "Washington Mutual - 9/10/2017"});
			events.Add(new Event { Title = "Bliss",
				Venue = "Tacoma Dome",
				VenueAdress = "2727 E D St Tacoma, WA",
				Description = "This show is going to be PURE BLISS.",
				StartDateAndTime = "10/10/2017 10:00PM",
				EndDateAndTime = "10/10/2017 10:00PM",
				VenueAndDate = "Tacoma Dome - 10/10/2017"});
			events.Add(new Event { Title = "Paradiso",
				Venue = "The Gorge",
				VenueAdress = "754 Silica Road NW George, WA",
				Description = "The biggest music festival of the year.",
				StartDateAndTime = "9/8/2017 10:00AM",
				EndDateAndTime = "9/11/2017 8:00PM",
				VenueAndDate = "The Gorge - 9/8/2017"});
			events.Add(new Event { Title = "Magnifique",
				Venue = "The Gorge",
				VenueAdress = "754 Silica Road NW George, WA",
				Description = "Another big concert at a sweet venue!",
				StartDateAndTime = "11/10/2017 8:00PM",
				EndDateAndTime = "11/12/2017 2:00AM",
				VenueAndDate = "The Gorge - 11/10/2017"});
			return events;
		}
	}
}
