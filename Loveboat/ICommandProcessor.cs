namespace Loveboat
{
    public interface ICommandProcessor
    {
        void Process<T>(T command);
    }
}