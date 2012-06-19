namespace Loveboat.CommandHandlers
{
    public interface ICommandHandler<T>
    {
        void Process(T command);
    }
}