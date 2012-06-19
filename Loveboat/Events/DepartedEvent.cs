using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loveboat.Aggregates;

namespace Loveboat.Events
{
    public class DepartedEvent : IEvent<Ship>
    {
        public DepartedEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public void ProcessInto(Ship aggregate)
        {
            aggregate.HandleEvent(this);
        }
    }
}