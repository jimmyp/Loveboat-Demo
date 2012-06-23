using System;
using System.Collections.Generic;
using Loveboat.Domain.Infrastructure;
using NServiceBus;

namespace Loveboat.Domain.Aggregates
{
    public class AggregateBase
    {
        public IList<IEvent> UncommitedEvents;

        public Guid Id { get; private set; }

        public void LoadFromEvents(Guid id, IEnumerable<IEvent> eventsForAggreate)
        {
            Id = id;
            foreach (var @event in eventsForAggreate)
                ApplyChange(@event, false);
        }

        protected void ApplyChange(IEvent @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(IEvent @event, bool isNew)
        {
            this.AsDynamic().HandleEvent(@event);
            if (isNew) UncommitedEvents.Add(@event);
        }
    }
}