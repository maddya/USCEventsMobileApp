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
		public List<List<string>> values { get; set; }
	}

	public class RewardsService
	{
		public HttpClient client = new HttpClient();

		public async Task<Dictionary<int, List<Reward>>> RefreshRewardsDataAsync()
		{
			var uri = new Uri($"{Configuration.GoogleSheetsDomain}/{Configuration.RewardsSpreadsheetId}/values/{Configuration.RewardsRangeQuery}?key={Configuration.GoogleSheetsAPIKey}");
			var response = await client.GetAsync(uri);
			GoogleSheetsRewardsResponse Item;
			//ObservableCollection<Reward> rewards = new ObservableCollection<Reward>();
			Dictionary<int, List<Reward>> point_values = new Dictionary<int, List<Reward>>();
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				Item = JsonConvert.DeserializeObject<GoogleSheetsRewardsResponse>(content);
				foreach (var r in Item.values) //each item in the sheet
				{
					//check if point value is in dictionary
					List<Reward> value;
					if (point_values.TryGetValue(int.Parse(r[4]), out value))
					{
                        value.Add(new Reward
                        {
                            Title = r[0],
                            Description = r[1],
                            ExpDateAndTime = r[2] + " " + r[3],
                            Points = int.Parse(r[4]),
                            //Fname = r[5],
                            //Lname = r[6],
                            Type = r[5],
                            RewardsImage = r[5] + ".png",
                            isRedeemed = false
						});
					}
					else //point value not yet in dictionary
					{
						Reward rew = new Reward
						{
							Title = r[0],
							Description = r[1],
							ExpDateAndTime = r[2] + " " + r[3],
							Points = int.Parse(r[4]),
							//Fname = r[5],
							//Lname = r[6],
							Type = r[5],
							RewardsImage = r[5] + ".png"
						};
						point_values.Add(int.Parse(r[4]), new List<Reward> { rew });
					}

					}

				// make dictionary into a list of each list of rewards 

					return point_values;
				}
				return null;
			}

		public Dictionary<int, List<Reward>> GetRewards()
		{
			var rewards = Task.Run(RefreshRewardsDataAsync).Result;
			return rewards;
		}
	}
}
