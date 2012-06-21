using System;
using NServiceBus;

namespace Loveboat.Messages.Events
{
    public class DepartedEvent : IEvent
    {
        public DepartedEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}