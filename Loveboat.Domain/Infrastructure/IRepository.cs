using System;
using Loveboat.Domain.Aggregates;
using Loveboat.Domain.Aggregates.Ship;

namespace Loveboat.Domain
{
    public interface IRepository<T> where T : AggregateBase
    {
        T GetById(Guid id);
        void Save(T aggregate);
    }

    public interface IShipRepository : IRepository<ShipAggregate>
    {
    }
}