using System;
using Loveboat.Aggregates;
using Loveboat.App_Start;
using Loveboat.Commands;

namespace Loveboat.Events
{
    public class ArrivedEvent : IEvent<Ship>
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

        public void ProcessInto(Ship aggregate)
        {
            aggregate.HandleEvent(this);
        }
    }
}