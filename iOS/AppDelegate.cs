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
		private CLBeaconRegion _region;

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
				_region = new CLBeaconRegion(new NSUuid("B9407F30-F5F8-466E-AFF9-25556B57FE6D"), "USC show");
				_locationManager.StartMonitoring(_region);
			}
		}

		void LocationRegionEntered(object sender, CLRegionEventArgs e)
		{
			//this function will be for when user gets in range of beacon

			//var regionCheckInPopup = await DisplayAlert("Show Region Entered", "Do you want to check in at this show to redeem points? " , "Yes", "Cancel");
			//if (regionCheckInPopup) //if user chooses to checkin....
			//{
			//	Navigation.PushAsync(new CheckinPage()); //if user selects confirm, call onredeem
			//}
			var notification = new UILocalNotification();
			notification.AlertBody = "Entered Region";
			UIApplication.SharedApplication.PresentLocalNotificationNow(notification);
		}

		void LocationRegionLeft(object sender, CLRegionEventArgs e)
		{
			//dont need to do anything when region is left? 
			//future --> thank you notification? 
		}

	}
}
