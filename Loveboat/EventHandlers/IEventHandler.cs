namespace Loveboat.EventHandlers
{
    public interface IEventHandler<T>
    {
        void Handle(T @event);
    }
}