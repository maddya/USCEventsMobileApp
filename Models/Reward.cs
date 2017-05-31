using System;
namespace USCEvents.Models
{
	public class Reward
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string ExpDateAndTime { get; set; }
		public int Points { get; set; }
		public string Type { get; set; }
		public string RewardsImage { get; set; }
        public bool isRedeemed { get; set; }

		public Reward(Reward other)
		{
            this.Title = other.Title;
            this.Description = other.Description;
            this.ExpDateAndTime = other.ExpDateAndTime;
            this.Points = other.Points;
            this.Type = other.Type;
            this.RewardsImage = other.RewardsImage;
            this.isRedeemed = other.isRedeemed;
		}

        public Reward() {
            
        }
	}
}
