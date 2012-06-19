using System;
using System.Collections.Generic;
using Loveboat.Aggregates;
using Loveboat.Events;
using Loveboat.Models;
using PetaPoco;

namespace Loveboat
{
    public class FakeEventStore
    {
        static FakeEventStore()
        {
            //Sync to view cache
            var viewModelCache = new ViewModelCache();
            var shipViewModels = viewModelCache.GetAll<ShipViewModel>();
            foreach (var shipViewModel in shipViewModels)
            {
                ShipEvents[shipViewModel.Id] = new List<IEvent<Ship>>();

                if (shipViewModel.Location == "At Sea")
                    ShipEvents[shipViewModel.Id].Add( new DepartedEvent(shipViewModel.Id));
                else
                    ShipEvents[shipViewModel.Id].Add(new ArrivedEvent(shipViewModel.Id, shipViewModel.Location));
            }
        }

        public static IDictionary<Guid, IList<IEvent<Ship>>> ShipEvents = new Dictionary<Guid, IList<IEvent<Ship>>>();
    }
}