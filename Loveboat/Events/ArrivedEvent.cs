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

        public void ProcessInto(Ship aggregate)
        {
            aggregate.HandleEvent(this);
        }
    }
}