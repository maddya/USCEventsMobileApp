using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace USCEvents.View
{
    public partial class ConsciousCrewPage : ContentPage
    {
        public ConsciousCrewPage()
        {
            InitializeComponent();
        }

		public void Handle_Clicked(object sender, System.EventArgs e)
		{
			var browser = new WebView();
			browser.Source = "https://www.facebook.com/USCConsciousC/";
			Content = browser;
		}
	}
}
