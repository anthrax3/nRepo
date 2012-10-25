using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo.RavenDB
{
    public class RavenDbDataAccessor<T> : IDataAccessor<T>
    {
        public RavenDbDataAccessor()
        {

        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(IList<T> entities)
        {
            throw new NotImplementedException();
        }

        public T Get(object key)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        public void Add(IList<T> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> CreateQuery()
        {
            throw new NotImplementedException();
        }
    }
}
