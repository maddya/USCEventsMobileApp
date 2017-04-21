using System;
namespace USCEvents.Models
{
	public class Event
	{
		public string Title { get; set; }
		public string Venue { get; set; }
		public string VenueAdress { get; set; }
		public string Description { get; set; }
		public DateTime StartDateAndTime { get; set; }
		public DateTime EndDateAndTime { get; set; }
		public string EventImageSource { get; set; }
		public string StartDateDisplayString { get; set; }
		public string EndDateDisplayString { get; set; }
		public string TimeDisplayString { get; set; }
	}
}
