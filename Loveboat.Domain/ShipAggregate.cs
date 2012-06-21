using System;
using System.Collections.Generic;
using Loveboat.Messages.Commands;
using Loveboat.Messages.Events;
using NServiceBus;

namespace Loveboat.Domain
{
    public class ShipAggregate : AggregateBase
    {
        public ShipAggregate()
        {
            UncommitedEvents = new List<IEvent>();
        }

        protected string CurrentLocation;

        public void HandleCommand(ArrivalCommand arrivalCommand)
        {
            if (CurrentLocation != "At Sea")
                throw new ApplicationException();

            ApplyChange(new ArrivedEvent(arrivalCommand));
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