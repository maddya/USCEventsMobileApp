using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CoreLocation;
using Foundation;
using UIKit;

namespace USCEvents.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		private CLLocationManager _locationManager;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			_locationManager = new CLLocationManager();
			_locationManager.AuthorizationChanged += LocationAuthChanged;
			_locationManager.RequestAlwaysAuthorization();
			_locationManager.RegionEntered += LocationRegionEntered;
			_locationManager.RegionLeft += LocationRegionLeft;
			LoadApplication(new App());


			return base.FinishedLaunching(app, options);
		}

		void LocationAuthChanged(object sender, CLAuthorizationChangedEventArgs e)
		{
			Debug.Write("Status: " + e.Status);
			if (e.Status == CLAuthorizationStatus.AuthorizedAlways)
			{
				//can't add region????
				_region = new CLBeaconRegion("b530fb1226b586f8c23e2f12e9d84635", "USC show");
				_locationManager.StartMonitoring(_region);
			}
		}

		async void LocationRegionEntered(object sender, CLRegionEventArgs e)
		{
			var regionCheckInPopup = await DisplayAlert("Show Region Entered", "Do you want to check in at this show to redeem points? " , "Yes", "Cancel");
			if (regionCheckInPopup) //if user chooses to checkin....
			{
				Navigation.PushAsync(new CheckinPage()); //if user selects confirm, call onredeem
			}
		}

		void LocationRegionLeft(object sender, CLRegionEventArgs e)
		{
			//dont need to do anything when region is left? 
			//future --> thank you notification? 
		}

	}
}
