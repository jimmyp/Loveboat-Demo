using System;
using Loveboat.Messages.Commands;
using NServiceBus;

namespace Loveboat.Messages.Events
{
    public class DepartedEvent : IEvent
    {
        public DepartedEvent(Guid id)
        {
            Id = id;
        }

        public DepartedEvent(DepatureCommand command)
        {
            Id = command.DepartingShipId;
        }

        public Guid Id { get; set; }
    }
}