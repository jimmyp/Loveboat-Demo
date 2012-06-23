using Loveboat.Messages.Commands;
using NServiceBus;

namespace Loveboat.Domain.CommandHandlers
{
    public class ArrivalCommandHandler : IHandleMessages<ArrivalCommand>
    {
        private readonly IShipRepository repository;

        public ArrivalCommandHandler(IShipRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(ArrivalCommand message)
        {
            var aggregate = repository.GetById(message.ArrivingShipId);

            aggregate.HandleCommand(message);

            repository.Save(aggregate);
        }
    }
}