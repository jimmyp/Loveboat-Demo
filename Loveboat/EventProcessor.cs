using Loveboat.EventHandlers;
using StructureMap;

namespace Loveboat
{
    public class EventProcessor
    {
        public void Process<T>(T @event)
        {
            var eventHandlers = ObjectFactory.GetAllInstances<IEventHandler<T>>();
            foreach (var eventHandler in eventHandlers)
                eventHandler.Handle(@event);
        }
    }
}