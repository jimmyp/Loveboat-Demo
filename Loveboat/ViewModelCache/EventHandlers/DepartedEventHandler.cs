using Loveboat.Messages.Events;
using Loveboat.ViewModels;
using NServiceBus;
using PetaPoco;

namespace Loveboat.ViewModelCache.EventHandlers
{
    public class DepartedEventHandler : IHandleMessages<DepartedEvent>
    {
        public DepartedEventHandler()
        {
            Database = new Database("viewModelCache");
        }

        protected Database Database;

        public void Handle(DepartedEvent @event)
        {
            var shipViewModel = Database.FirstOrDefault<ShipViewModel>("SELECT * FROM ShipViewModel WHERE Id = @0", @event.Id);
            
            if (shipViewModel == null) return;

            shipViewModel.Location = "At Sea";
            Database.Save(shipViewModel);
        }
    }
}