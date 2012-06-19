using System.Collections.Generic;
using PetaPoco;

namespace Loveboat
{
    public class ViewModelCache : IViewModelCache
    {
        public ViewModelCache()
        {
            Database = new Database("viewModelCache");
        }

        protected Database Database;

        public IEnumerable<T> GetAll<T>()
        {
            var tableName = typeof (T).Name;
            return Database.Fetch<T>("SELECT * FROM " + tableName);
        }
    }
}