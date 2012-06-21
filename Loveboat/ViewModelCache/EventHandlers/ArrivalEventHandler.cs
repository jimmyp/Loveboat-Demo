using Loveboat.Messages.Events;
using Loveboat.ViewModels;
using NServiceBus;
using PetaPoco;

namespace Loveboat.ViewModelCache.EventHandlers
{
    public class ArrivalEventHandler : IHandleMessages<ArrivedEvent>
    {
        public ArrivalEventHandler()
        {
            Database = new Database("viewModelCache");
        }

        protected Database Database;

        public void Handle(ArrivedEvent @event)
        {
            var shipViewModel = Database.FirstOrDefault<ShipViewModel>("SELECT * FROM ShipViewModel WHERE Id = @0", @event.Id);
            
            if (shipViewModel == null) return;

            shipViewModel.Location = @event.ArrivalPort;
            Database.Save(shipViewModel);
        }
    }
}