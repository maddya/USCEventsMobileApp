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
					events.Add(new Event { 
						Title = e[0],
						Venue = e[1],
						VenueAdress = e[2],
						Description = e[3],
						StartDateAndTime = Convert.ToDateTime(e[4] + " " + e[5]),
						EndDateAndTime = Convert.ToDateTime(e[6] + " " + e[7]),
						EventImageSource = e[8]});
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

		public async Task<List<Event>> GetGoogleEvents()
		{
			var events = await DependencyService.Get<IGoogleService>().GetEventsAsync();
			return events;
		}
	}

	public interface IGoogleService
	{
		Task<List<Event>> GetEventsAsync();	
	}
}
