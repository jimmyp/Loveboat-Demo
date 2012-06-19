using System;
using System.Collections.Generic;
using Loveboat.App_Start;
using Loveboat.Events;

namespace Loveboat
{
    public class FakeDB
    {
        public static IDictionary<Guid, IList<IEvent<Ship>>> ShipEvents = new Dictionary<Guid, IList<IEvent<Ship>>>();
    }
}