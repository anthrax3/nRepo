using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo.Events
{
    public interface IQueryInterceptor
    {
        bool CanHandle<T>();
        IQueryable<T> Handle<T>(IQueryable<T> queryable);


    }
}
