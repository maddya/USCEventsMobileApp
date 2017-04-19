using System;
namespace USCEvents.Models
{
	public class Event
	{
		public string Title { get; set; }
		public string Venue { get; set; }
		public string VenueAdress { get; set; }
		public string Description { get; set; }
		public string StartDateAndTime { get; set; }
		public string EndDateAndTime { get; set; }
		public string VenueAndDate { get; set; }
		public string EventImageSource { get; set; }
		//public DateTime StartTime { get; set; }
		//public DateTime EndTime { get; set; }
	}
}
