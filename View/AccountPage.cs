using System;
using System.Collections.Generic;
using USCEvents.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class AccountPage : ContentPage
	{
		//public static string myname = App.myName;

		public AccountPage()
		{
			InitializeComponent();
			name.Text = App.me.Name;
			profileImage.Source = App.me.Picture.Data.Url;
			id.Text = App.me.Id;
            points.Text = App.me.Points + " points";
		}
	}
}
