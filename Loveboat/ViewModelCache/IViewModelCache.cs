using System.Collections.Generic;

namespace Loveboat.ViewModelCache
{
    public interface IViewModelCache
    {
        IEnumerable<T> GetAll<T>();
    }
}