using System;
using System.Collections.Generic;
using NServiceBus;

namespace Loveboat.Domain
{
    public class AggregateBase
    {
        public IList<IEvent> UncommitedEvents;

        public Guid Id { get; set; }

        public void LoadFromEvents(IEnumerable<IEvent> eventsForAggreate)
        {
            foreach (var @event in eventsForAggreate)
                ApplyChange(@event, false);
        }

        protected void ApplyChange(IEvent @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(IEvent @event, bool isNew)
        {
            this.AsDynamic().Apply(@event);
            if (isNew) UncommitedEvents.Add(@event);
        }
    }
}