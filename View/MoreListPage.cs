using System;

using Xamarin.Forms;

namespace USCEvents
{
	public class MoreListPage : ContentPage
	{
		public MoreListPage()
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

