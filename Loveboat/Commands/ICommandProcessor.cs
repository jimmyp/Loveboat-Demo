namespace Loveboat.Commands
{
    public interface ICommandProcessor
    {
        void Process<T>(T command);
    }
}