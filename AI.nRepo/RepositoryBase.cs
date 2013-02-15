using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AI.nRepo
{
    public abstract class RepositoryBase<T> : IRepository<T>
    {
        private readonly IDataAccessor<T> _dataAccessor;
        
        public RepositoryBase(IRepositoryConfiguration repoConfiguration)
        {
            _dataAccessor = repoConfiguration.Create<T>();
        }

        public virtual void Add(T entity)
        {
            _dataAccessor.Add(entity);
        }

        protected IList<T> ExecuteQuery(string query)
        {
            return _dataAccessor.ExecuteQuery(query);
        } 

        public virtual void Remove(T entity)
        {
            _dataAccessor.Remove(entity);
        }

        public virtual void Remove(IList<T> entities)
        {
            _dataAccessor.Remove(entities);
        }

        public virtual T Get(object key)
        {
            return _dataAccessor.Get(key);
        }

        public virtual IList<T> GetAll()
        {
            return _dataAccessor.GetAll();
        }

        public virtual IList<T> GetAll(int pageSize, int pageNumber)
        {
            return _dataAccessor.GetAll(pageSize, pageNumber);
        }

        public void BeginTransaction()
        {
            _dataAccessor.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dataAccessor.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _dataAccessor.RollbackTransaction();
        }

        public virtual void Add(IList<T> entities)
        {
            _dataAccessor.Add(entities);
        }

        public IQueryable<T> CreateQuery()
        {
            return _dataAccessor.CreateQuery();
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return this.CreateQuery().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();

        }

        public Type ElementType
        {
            get { return this.CreateQuery().ElementType; }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return this.CreateQuery().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return this.CreateQuery().Provider; }
        }

        public void Dispose()
        {
            _dataAccessor.Dispose();
        }
    }
}
