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

			EventsView.ItemTapped += async (sender, e) =>
			{
				await Navigation.PushAsync(new EventDetailsPage(e.Item as Event));
				((ListView)sender).SelectedItem = null;
			};
		}
	}
}
