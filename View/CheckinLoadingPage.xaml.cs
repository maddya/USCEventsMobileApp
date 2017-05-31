﻿using System;
using System.Collections.Generic;
using USCEvents.Models;
using USCEvents.Services;
using Xamarin.Forms;
using Estimotes;

namespace USCEvents.View
{
    public partial class CheckinLoadingPage : ContentPage
    {
        private EventsService eventsService { get; set; }
        private List<Event> events { get; set; }

        private BeaconService beacons { get; set; }


        public CheckinLoadingPage()
        {
			beacons = new BeaconService();
            var successMessage = beacons.Initialize();
            //GC.KeepAlive(EstimoteManager.Instance);
            InitializeComponent();
            eventsService = new EventsService();
            events = eventsService.GetEvents();
            DateTime time = DateTime.Now;
            Event currentEvent = null;
			foreach (Event e in events)
            {
                if (time > e.StartDateAndTime && time < e.EndDateAndTime) //if an event is going on now...
				{
					beaconmessage.Text = "Searching for Beacon signal, if not found within 30 seconds, please go to the booth and contact a staff member.";
                    currentEvent = e;
                }   

            }
            if (currentEvent != null) {
				EstimoteManager.Instance.Ranged += async (sender, beacons) => //if a beacon is ranged
                {
                    foreach (var beacon in beacons)
                    {
                        //DisplayAlert("You're in that range", null, "cool"); 
                        App.me.Points += currentEvent.Points;
                        FirebaseService f = new FirebaseService();
                        await f.UpdateUser();
                        await Navigation.PushAsync(new CheckInPage()); //send them to confirmed 
                        EstimoteManager.Instance.StopRanging(new BeaconRegion("estimote", "B9407F30-F5F8-466E-AFF9-25556B57FE6D"));
                    }
                };
            } else {
                beaconmessage.Text = "There are no events currently taking place.  Try again during the next show.";   
            }
		}
    }
}
