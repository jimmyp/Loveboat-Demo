using System;
using System.Collections.Generic;
using NServiceBus;

namespace Loveboat.Domain
{
    public class EventsForAggreate
    {
        public Type Type { get; set; }
        public Guid Id { get; set; }
        public IList<IEvent> Events { get; set; }

        public EventsForAggreate(Type type, Guid id, IList<IEvent> events)
        {
            if (type == null) throw new ArgumentNullException("type");
            if (events == null) throw new ArgumentNullException("events");
            Type = type;
            Id = id;
            Events = events;
        }
    }
}