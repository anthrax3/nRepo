using System.Data.EntityClient;
using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo.EF
{
    public class EntityFrameworkDataAccessor<T> : IDataAccessor<T>
    {
        private string _connectionString;
        
        public EntityFrameworkDataAccessor(string connectionString)
        {
            this._connectionString = connectionString;
            
        }

        public void Add(T entity)
        {
            
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


        public IList<T> ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
