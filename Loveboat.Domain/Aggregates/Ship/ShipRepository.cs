using Loveboat.Domain.Infrastructure;
using NServiceBus;

namespace Loveboat.Domain.Aggregates.Ship
{
    public class ShipRepository : Repository<ShipAggregate>, IShipRepository
    {
        public ShipRepository(IBus bus) : base(bus)
        {
        }
    }
}
