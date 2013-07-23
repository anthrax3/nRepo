using System.Collections;
using System.Linq.Expressions;
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
        protected RepositoryBase(string alias)
        {
            var repoConfiguration = Configure.MasterConfiguration.GetConfiguration(alias);
            _dataAccessor = repoConfiguration.Create<T>();
        }



        public virtual IUnitOfWork UnitOfWork
        {
            set
            {
                value.AddWorkItem(this);
            }
        }
        public virtual void Add(T entity)
        {
            RepositoryEventRegistry.RaiseEvent<IBeforeAddListener>(entity);
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
            return CreateQuery().GetEnumerator();
        }
       
        public Type ElementType
        {
            get { return this.CreateQuery().ElementType; }
        }

        public Expression Expression
        {
            get { return CreateQuery().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return CreateQuery().Provider; }
        }

        public void Dispose()
        {
            _dataAccessor.Dispose();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
