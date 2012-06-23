using Loveboat.Messages.Commands;
using NServiceBus;

namespace Loveboat.Domain
{
    public class DepartureCommandHandler : IHandleMessages<DepatureCommand>
    {
        private readonly IShipRepository repository;

        public DepartureCommandHandler(IShipRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(DepatureCommand message)
        {
            var aggregate = repository.GetById(message.DepartingShipId);

            aggregate.HandleCommand(message);

            repository.Save(aggregate);
        }
    }
}