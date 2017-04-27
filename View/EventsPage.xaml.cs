using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using USCEvents.Models;
using USCEvents.Services;
using Xamarin.Forms;

namespace USCEvents
{
	public partial class EventsPage : ContentPage
	{
		private List<Event> events { get; set; }
		private EventsService eventsService = new EventsService();
		//private IEventsService _eventsService;

		public EventsPage()
		{
			//_eventsService = eventsService;	
			InitializeComponent();
			events = eventsService.GetEvents();

			 Task.Run(new Func<Task>(async() =>
		    {
		         var events2 = await eventsService.GetGoogleEvents();
		    }));
		      
			EventsView.ItemsSource = events;
			EventsView.ItemTapped += async (sender, e) =>
			{
				await Navigation.PushAsync(new EventDetailsPage(e.Item as Event));
				((ListView)sender).SelectedItem = null;
			};
		}
	}
}
