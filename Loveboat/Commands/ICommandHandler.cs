namespace Loveboat.Commands
{
    public interface ICommandHandler<T>
    {
        void Process(T command);
    }
}