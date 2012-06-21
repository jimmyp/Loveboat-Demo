using System;
using System.Collections.Generic;
using Loveboat.Messages.Events;
using Loveboat.ViewModels;
using NServiceBus;

namespace Loveboat.Domain
{
    public class FakeEventStore
    {
        static FakeEventStore()
        {
            //Sync to view cache
            var viewModelCache = new ViewModelCache.ViewModelCache();
            var shipViewModels = viewModelCache.GetAll<ShipViewModel>();
            
            foreach (var shipViewModel in shipViewModels)
            {
                if (Events[shipViewModel.Id] == null) Events[shipViewModel.Id] = new List<IEvent>(); 

                if (shipViewModel.Location == "At Sea")
                    Events[shipViewModel.Id].Add(new DepartedEvent(shipViewModel.Id));
                else
                    Events[shipViewModel.Id].Add(new ArrivedEvent(shipViewModel.Id, shipViewModel.Location));
            }
        }

        public static IDictionary<Guid, IList<IEvent>> Events = new Dictionary<Guid, IList<IEvent>>();
    }
}