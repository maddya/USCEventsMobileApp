using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using USCEvents.Models;
using Xamarin.Forms;

namespace USCEvents.Services
{
	public class GoogleSheetsRewardsResponse
	{
		//public string range { get; set; }
		//public string majorDimension { get; set; }
		public List<List<string>> values { get; set; }
	}

	public class RewardsService
	{
		public HttpClient client = new HttpClient();

		public async Task<List<Reward>> RefreshRewardsDataAsync()
		{
			var uri = new Uri($"{Configuration.GoogleSheetsDomain}/{Configuration.RewardsSpreadsheetId}/values/{Configuration.RewardsRangeQuery}?key={Configuration.GoogleSheetsAPIKey}");
			var response = await client.GetAsync(uri);
			GoogleSheetsRewardsResponse Item;
			List<Reward> rewards = new List<Reward>();
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				Item = JsonConvert.DeserializeObject<GoogleSheetsRewardsResponse>(content);
				foreach (var r in Item.values)
				{
					rewards.Add(new Reward
					{
						Title = r[0],
						Description = r[1],
						ExpDateAndTime = r[2] + " " + r[3],
						Points = int.Parse(r[4]),
						//Fname = r[5],
						//Lname = r[6],
						Type = r[5],
						RewardsImage = r[5]+".png"
					});
					
				}
				return rewards;
			}
			return null;
		}

		public List<Reward> GetRewards()
		{
			var rewards = Task.Run(RefreshRewardsDataAsync).Result;
			return rewards;
		}
	}
}
