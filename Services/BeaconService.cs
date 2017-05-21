using System;
using System.Diagnostics;
using Estimotes;

namespace USCEvents
{
	public class BeaconService
	{
		public BeaconService()
		{
		}

		public async void Initialize()
		{

			var status = await EstimoteManager.Instance.Initialize(); // optionally pass false to authorize foreground ranging only
            if (status != BeaconInitStatus.Success)
			{
				//... You have a problem with permissions or bluetooth is unavailable on the device, use the enum to figure out what!
				Debug.WriteLine("it didn't work");
			}
			else
			{
				// for exact distancing, use ranging - requires your app to be in the foreground
				var region = new BeaconRegion("estimote", "B9407F30-F5F8-466E-AFF9-25556B57FE6D");
				EstimoteManager.Instance.StartRanging(region);
				//EstimoteManager.Instance.StopRanging(new BeaconRegion("Beacon Identifier", "Your UUID"));

			}
		}
	}
}