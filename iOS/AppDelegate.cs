using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CoreLocation;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace USCEvents.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			UITabBar.Appearance.TintColor = Xamarin.Forms.Color.FromHex("#c900c6").ToUIColor ();
			LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}

	}
}
