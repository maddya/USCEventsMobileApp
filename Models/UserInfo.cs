using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using USCEvents.Models;

namespace USCEvents
{
	public class UserInfo
	{
		public string Name { get; set; }
		public string Id { get; set; }
		[JsonProperty("first_name")]
		public string FirstName { get; set; }
		[JsonProperty("last_name")]
		public string LastName { get; set; }
		public Picture Picture { get; set; }
        public int Points { get; set; }
        public List<Reward> myRewards = new List<Reward>();
        //public string FacebookID { get; set;  }
	}

	public class Picture
	{
		public Data Data { get; set; }
	}

	public class Data
	{
		public bool IsSilhouette { get; set; }
		public string Url { get; set; }
	}
}