using System;
using System.Collections.Generic;
using Loveboat.Commands;
using Loveboat.Events;

namespace Loveboat.Aggregates
{
    public class Ship
    {
        protected EventProcessor EventProcessor;
        public IList<IEvent<Ship>> UncommitedEvents;

        public Ship()
        {
            EventProcessor = new EventProcessor();
            UncommitedEvents = new List<IEvent<Ship>>();
        }

        public Guid Id { get; set; }
        protected string CurrentLocation;

        public void HandleCommand(ArrivalCommand arrivalCommand)
        {
            if (CurrentLocation != "At Sea")
                throw new ApplicationException();

            Apply(new ArrivedEvent(arrivalCommand));
        }

        private void Apply(ArrivedEvent arrivedEvent)
        {
            UncommitedEvents.Add(arrivedEvent);
            arrivedEvent.ProcessInto(this);
            EventProcessor.Process(arrivedEvent);
        }


        public void HandleEvent(ArrivedEvent arrivedEvent)
        {
            if (CurrentLocation != "At Sea")
                throw new ApplicationException();

            CurrentLocation = arrivedEvent.ArrivalPort;
        }

        public void HandleEvent(DepartedEvent departedEvent)
        {
            if (CurrentLocation == "At Sea")
                throw new ApplicationException();

            CurrentLocation = "At Sea";
        }
    }
}