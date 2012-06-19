using System;

namespace Loveboat.Events
{
    public interface IEvent<T>
    {
        Guid Id { get; set; }

        void ProcessInto(T aggregate);
    }
}