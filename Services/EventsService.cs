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
			events.Add(new Event { Title = "Bass Academy", Venue = "Tacoma Dome" });
			events.Add(new Event { Title = "Life in Color", Venue = "Washington Mutual" });
			events.Add(new Event { Title = "Bliss", Venue = "Tacoma Dome" });
			events.Add(new Event { Title = "Paradiso", Venue = "The Gorge"});
			events.Add(new Event { Title = "Magnifique", Venue = "The Gorge" });
			return events;
		}
	}
}
