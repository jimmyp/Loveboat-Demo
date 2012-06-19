using Loveboat.CommandHandlers;
using StructureMap;

namespace Loveboat
{
    public class CommandProcessor : ICommandProcessor
    {
        public void Process<T>(T command)
        {
            var handlers = ObjectFactory.GetAllInstances<ICommandHandler<T>>();
            foreach (var handler in handlers)
                handler.Process(command);
        }
    }
}