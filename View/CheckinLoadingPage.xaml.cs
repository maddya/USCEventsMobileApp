using System;
using System.Collections.Generic;
using USCEvents.Models;
using USCEvents.Services;
using Xamarin.Forms;
using Estimotes;

namespace USCEvents.View
{
    public partial class CheckinLoadingPage : ContentPage
    {
        private EventsService eventsService = new EventsService();
        private List<Event> events { get; set; }

		BeaconService beacons;

		bool UserAlerted;
        public CheckinLoadingPage()
        {
            InitializeComponent();
            events = eventsService.GetEvents();
            DateTime time = DateTime.Now;
            beaconmessage.Text = "There are no events currently taking place.  Try again during the next show.";
            foreach (Event e in events)
            {
                    if (time > e.StartDateAndTime && time < e.EndDateAndTime) //if an event is going on now...
				{
					beaconmessage.Text = "Searching for Beacon signal, if not found within 30 seconds, please go to the booth and contact a staff member.";
					
                    //start ranging for beacons
                    beacons = new BeaconService();
					beacons.Initialize();
					InitializeComponent();

					UserAlerted = false;


					EstimoteManager.Instance.Ranged += (sender, beacons) => //if a beacon is ranged
					{
						if (!UserAlerted) //if they have not yet been told
						{
							//DisplayAlert("You're in that range", null, "cool"); 
                            Navigation.PushAsync(new CheckinPage(e)); //send them to confirmed 
							UserAlerted = true;
						}
						EstimoteManager.Instance.StopRanging(new BeaconRegion("estimote", "B9407F30-F5F8-466E-AFF9-25556B57FE6D"));
					};

                }   

            }

        }
    }
}
