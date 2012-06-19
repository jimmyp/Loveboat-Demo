using System;
using System.Collections.Generic;
using Loveboat.Commands;
using Loveboat.Events;

namespace Loveboat.App_Start
{
    public class Ship
    {
        public IList<IEvent<Ship>> UncommitedEvents;

        public Ship()
        {
            UncommitedEvents = new List<IEvent<Ship>>();
        }

        public Guid Id { get; set; }
        protected string CurrentLocation;

        public void HandleCommand(ArrivalCommand arrivalCommand)
        {
            if (CurrentLocation != null && CurrentLocation != "At Sea")
                throw new ApplicationException();

            var arrivedEvent = new ArrivedEvent(arrivalCommand);
            UncommitedEvents.Add(arrivedEvent);
            arrivedEvent.ProcessInto(this);
        }
        
        public void HandleEvent(ArrivedEvent arrivedEvent)
        {
            if (CurrentLocation != null && CurrentLocation != "At Sea")
                throw new ApplicationException();

            CurrentLocation = arrivedEvent.ArrivalPort;
        }
    }
}