using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		public async Task<ObservableCollection<Reward>> RefreshRewardsDataAsync()
		{
			var uri = new Uri($"{Configuration.GoogleSheetsDomain}/{Configuration.RewardsSpreadsheetId}/values/{Configuration.RewardsRangeQuery}?key={Configuration.GoogleSheetsAPIKey}");
			var response = await client.GetAsync(uri);
			GoogleSheetsRewardsResponse Item;
			ObservableCollection<Reward> rewards = new ObservableCollection<Reward>();
			//Dictionary<int, Reward> point_values = new Dictionary<int, Reward>();
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				Item = JsonConvert.DeserializeObject<GoogleSheetsRewardsResponse>(content);
				foreach (var r in Item.values) //each item in the sheet
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
					//if point value exists already
					//if (point_values.ContainsKey(int.Parse(r[4])))
     //  				{
     //       			//add r to be associated with that value 

     //   			}
					//else 
					//{
					//	point_values.Add(int.Parse(r[4]),new List<Reward> (r)
						
					
				}
				return rewards;
			}
			return null;
		}

		public ObservableCollection<Reward> GetRewards()
		{
			var rewards = Task.Run(RefreshRewardsDataAsync).Result;
			return rewards;
		}
	}
}
