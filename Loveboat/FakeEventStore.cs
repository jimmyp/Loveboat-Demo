using System;
using System.Collections.Generic;
using Loveboat.Aggregates;
using Loveboat.Events;

namespace Loveboat
{
    public class FakeEventStore
    {
        public static IDictionary<Guid, IList<IEvent<Ship>>> ShipEvents = new Dictionary<Guid, IList<IEvent<Ship>>>();
    }
}