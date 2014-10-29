using System.Collections;
using System.Linq.Expressions;
using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI.nRepo.Events;


namespace AI.nRepo
{
    using System.Data;

    public abstract class RepositoryBase<T> : IRepository<T>
        where T : class
    {
        private IDataAccessor<T> _dataAccessor;
        //private IUnitOfWork _unitOfWork;
        private string _defaultAlias;
        protected RepositoryBase(string alias)
        {
            _defaultAlias = alias;
            SetAccessor(alias);
        }

        protected virtual IsolationLevel GetIsolationLevel()
        {
            return IsolationLevel.ReadCommitted;
        }

        public IDataAccessor<T> SetAccessor(string alias)

        {
            var repoConfiguration = Configure.MasterConfiguration.GetConfiguration(alias);
            _dataAccessor = repoConfiguration.Create<T>();
            _dataAccessor.SetIsolationLevel(GetIsolationLevel());
           // _unitOfWork = repoConfiguration.GetCurrentUnitOfWork();
            return _dataAccessor;
        }

        public IDataAccessor<T> GetDataAccessor()
        {
            return _dataAccessor ;
        }

        //public virtual IUnitOfWork UnitOfWork
        //{
        //    get
        //    {
        //        return _unitOfWork;
        //    }
        //}
        public virtual void Add(T entity)
        {
            RepositoryEventRegistry.RaiseEvent<IBeforeAddListener>(entity);
            GetDataAccessor().Add(entity);
            RepositoryEventRegistry.RaiseEvent<IAfterAddListener>(entity);
            
        }

        protected IList<T> ExecuteQuery(string query)
        {
           
            return GetDataAccessor().ExecuteQuery(query);
        } 

        public virtual void Remove(T entity)
        {
            RepositoryEventRegistry.RaiseEvent<IBeforeRemoveListener>(entity);
            GetDataAccessor().Remove(entity);
            RepositoryEventRegistry.RaiseEvent<IAfterRemoveListener>(entity);
        }

        public virtual void Remove(IList<T> entities)
        {
            foreach (var entity in entities)
                this.Remove(entity);
        }

        public virtual T Get(object key)
        {
            return GetDataAccessor().Get(key);
        }

        public virtual IList<T> GetAll()
        {
            return GetDataAccessor().GetAll();
        }

        public virtual IList<T> GetAll(int pageSize, int pageNumber)
        {
            return GetDataAccessor().GetAll(pageSize, pageNumber);
        }

        public virtual void BeginTransaction()
        {
            //if(_unitOfWork == null)
                GetDataAccessor().BeginTransaction();
        }

        public virtual void CommitTransaction()
        {
            //if (_unitOfWork == null)
                GetDataAccessor().CommitTransaction();
        }

        public virtual void RollbackTransaction()
        {
           // if (_unitOfWork == null)
                GetDataAccessor().RollbackTransaction();
        }

        public virtual void Add(IList<T> entities)
        {
            foreach (var entity in entities)
                this.Add(entity);
        }

        public IQueryable<T> CreateQuery()
        {
            var query = GetDataAccessor().CreateQuery();
            var eventHandlers = RepositoryEventRegistry.GetQueryInterceptors<T>();
            foreach (var handler in eventHandlers)
            {
                query = handler.Handle(query);
            }
            return query;
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
            //this._unitOfWork.Dispose();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }
}
