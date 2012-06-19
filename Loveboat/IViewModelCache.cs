using System.Collections.Generic;

namespace Loveboat
{
    public interface IViewModelCache
    {
        IEnumerable<T> GetAll<T>();
    }
}