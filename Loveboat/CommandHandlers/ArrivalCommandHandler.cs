using System;
using System.Collections.Generic;
using Loveboat.Aggregates;
using Loveboat.App_Start;
using Loveboat.Commands;
using Loveboat.Events;

namespace Loveboat.CommandHandlers
{
    public class ArrivalCommandHandler : ICommandHandler<ArrivalCommand>
    {
        public void Process(ArrivalCommand command)
        {
            //This can go into a repository.Get() but requires some sneaky code
            var aggregate = new Ship();

            var events = GetEventsFor(command.ArrivingShipId);

            foreach (var @event in events)
                    @event.ProcessInto(aggregate);

            aggregate.HandleCommand(command);

            //This can go into a repository.Save() but requires some more sneaky code
            foreach (var uncommitedEvent in aggregate.UncommitedEvents)
                events.Add(uncommitedEvent);
        }

        //Ignore this... just here becuase I don't have a real event store
        private static IList<IEvent<Ship>> GetEventsFor(Guid id)
        {
            IList<IEvent<Ship>> events;
            FakeEventStore.ShipEvents.TryGetValue(id, out events);
            if (events == null)
            {
                events = new List<IEvent<Ship>>();
                FakeEventStore.ShipEvents[id] = events;
            }
            return events;
        }
    }
}