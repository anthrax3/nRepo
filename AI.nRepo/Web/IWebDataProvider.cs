using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo.Web
{
    public interface IWebDataProvider
    {
        void Add(object entity);

        void Remove(object entity);

        T Get<T>(object key);

        IQueryable<T> GetQueryable<T>();
    }
}
