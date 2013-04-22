using System.Data.Entity;
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
        private readonly string _connectionString;
        private DbContext _context;

        public EntityFrameworkDataAccessor(string connectionString)
        {
            this._connectionString = connectionString;
        }

        //public void Add(T entity)
        //{
        //    _context.Set<T>().Add(entity);
        //}

        //public void Remove(T entity)
        //{
        //    _context.Set<T>().Remove(entity);
        //}

        //public void Remove(IList<T> entities)
        //{
        //    entities.ToList().ForEach(x => _context.Set<T>().Remove(x));
        //}

        //public T Get(object key)
        //{
        //    EnsureContext();
        //    return _context.Set<T>().Find(Convert.ToString(key));
        //}
        
        //public IList<T> GetAll()
        //{
        //    EnsureContext();
        //    return _context.Set<T>().ToList();
        //}

        //public IList<T> GetAll(int pageSize, int pageNumber)
        //{
        //    return _context.Set<T>().Skip(pageSize*pageNumber).Take(pageSize).ToList();
        //}

        //private void EnsureContext()
        //{
        //    if (_context == null)
        //    {
        //        _context = new DbContext(_connectionString);
        //    }
        //}

        //public void BeginTransaction()
        //{
        //    EnsureContext();
        //}

        //public void CommitTransaction()
        //{
        //    _context.SaveChanges();
        //}

        //public void RollbackTransaction()
        //{

        //}

        //public void Add(IList<T> entities)
        //{
        //    entities.ToList().ForEach(x => _context.Set<T>().Add(x));
        //}

        //public IQueryable<T> CreateQuery()
        //{
        //    return _context.Set<T>();
        //}

        //public IList<T> ExecuteQuery(string query)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
        public void Dispose()
        {
            throw new NotImplementedException();
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

        public IList<T> ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }
    }
}
