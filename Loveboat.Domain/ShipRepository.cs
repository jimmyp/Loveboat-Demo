using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace Loveboat.Domain
{
    public class ShipRepository : Repository<ShipAggregate>, IShipRepository
    {
        public ShipRepository(IBus bus) : base(bus)
        {
        }
    }
}
