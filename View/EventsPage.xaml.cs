using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using USCEvents.Models;
using USCEvents.Services;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class EventsPage : ContentPage
	{
		private List<Event> events { get; set; }
		private EventsService eventsService = new EventsService();

		public EventsPage()
		{
			InitializeComponent();
			events = eventsService.GetEvents();
			EventsView.ItemsSource = events;
		}

		private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem;
			Navigation.PushAsync(new EventDetailsPage((Event) item));
		}
	}
}
