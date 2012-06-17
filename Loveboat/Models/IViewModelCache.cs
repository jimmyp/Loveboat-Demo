using System.Collections.Generic;

namespace Loveboat.Models
{
    public interface IViewModelCache
    {
        IEnumerable<T> GetAll<T>();
    }
}