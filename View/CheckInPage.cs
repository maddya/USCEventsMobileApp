using System;

using Xamarin.Forms;

namespace USCEvents
{
	public class CheckInPage : ContentPage
	{
		public CheckInPage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

