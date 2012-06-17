using System.Collections.Generic;
using Loveboat.Controllers;
using PetaPoco;

namespace Loveboat.Models
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