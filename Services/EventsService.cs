using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using USCEvents.Models;
using Xamarin.Forms;

namespace USCEvents.Services
{
	public class GoogleSheetsResponse
	{
		public string range { get; set; }
		public string majorDimension { get; set; }
		public List<List<string>> values { get; set; }
	}

	public class EventsService
	{
		public HttpClient client = new HttpClient();

		public async Task<List<Event>> RefreshDataAsync()
		{
			var uri = new Uri($"{Configuration.GoogleSheetsDomain}/{Configuration.EventsSpreadsheetId}/values/{Configuration.EventsRangeQuery}?key={Configuration.GoogleSheetsAPIKey}");
			var response = await client.GetAsync(uri);
			GoogleSheetsResponse Item;
			List<Event> events = new List<Event>();
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				Item = JsonConvert.DeserializeObject<GoogleSheetsResponse>(content);
                foreach (var e in Item.values)
				{
                    events.Add(new Event
                    {
                        Title = e[0],
                        Venue = e[1],
                        VenueAdress = e[2],
                        Description = e[3],
                        StartDateAndTime = Convert.ToDateTime(e[4] + " " + e[5]),
                        EndDateAndTime = Convert.ToDateTime(e[6] + " " + e[7]),
                        EventImageSource = e[8],
                        Points = Convert.ToInt32(e[9])
					});
				}
				return events;
			}
			return null;
		}


		public List<Event> GetEvents()
		{
			var events = Task.Run(RefreshDataAsync).Result;
			return events;
		}

		//public List<Event> GetDummyEvents()
		//{
		//	var events = new List<Event>();
		//	events.Add(new Event { Title = "Bass Academy", 
		//		Venue = "Tacoma Dome",
		//		VenueAdress = "2727 E D St Tacoma, WA",
		//		Description = "Some heavy bass at the academy.",
		//		StartDateAndTime = "8/17/2017 9:00PM",
		//		EndDateAndTime = "8/18/2017 2:00AM"});
		//	events.Add(new Event { Title = "Life in Color",
		//		Venue = "Washington Mutual",
		//		VenueAdress = "800 Occidental Ave S Seattle, WA",
		//		Description = "Their life is in color, believe it or not.",
		//		StartDateAndTime = "9/10/2017 9:30PM",
		//		EndDateAndTime = "9/11/2017 2:00AM"});
		//	events.Add(new Event { Title = "Bliss",
		//		Venue = "Tacoma Dome",
		//		VenueAdress = "2727 E D St Tacoma, WA",
		//		Description = "This show is going to be PURE BLISS.",
		//		StartDateAndTime = "10/10/2017 10:00PM",
		//		EndDateAndTime = "10/10/2017 10:00PM"});
		//	events.Add(new Event { Title = "Paradiso",
		//		Venue = "The Gorge",
		//		VenueAdress = "754 Silica Road NW George, WA",
		//		Description = "The biggest music festival of the year.",
		//		StartDateAndTime = "9/8/2017 10:00AM",
		//		EndDateAndTime = "9/11/2017 8:00PM"});
		//	events.Add(new Event { Title = "Magnifique",
		//		Venue = "The Gorge",
		//		VenueAdress = "754 Silica Road NW George, WA",
		//		Description = "Another big concert at a sweet venue!",
		//		StartDateAndTime = "11/10/2017 8:00PM",
		//		EndDateAndTime = "11/12/2017 2:00AM"});
		//	return events;
		//}
	}
}
