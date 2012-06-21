using System;
using Loveboat.Messages.Commands;
using NServiceBus;

namespace Loveboat.Messages.Events
{
    public class ArrivedEvent : IEvent
    {

        public string ArrivalPort { get; set; }
        public Guid Id { get; set; }

        public ArrivedEvent(ArrivalCommand arrivalCommand)
        {
            Id = arrivalCommand.ArrivingShipId;
            ArrivalPort = arrivalCommand.ArrivalPort;
        }

        public ArrivedEvent(Guid arrivalCommand, string arrivalPort)
        {
            if (arrivalPort == null) throw new ArgumentNullException("arrivalPort");
            Id = arrivalCommand;
            ArrivalPort = arrivalPort;
        }
    }
}