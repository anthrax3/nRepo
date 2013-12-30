using System.Collections.Generic;
using System.Linq;
using AI.nRepo.Configuration;
using NHibernate;
using NHibernate.Linq;

namespace AI.nRepo.NHibernate
{
    public class NHibernateDataAccessor<T> : IDataAccessor<T>, IUnitOfWorkItem
    {
        private readonly ISessionBuilder _sessionBuilder;
        protected ISession CurrentSession;

        public NHibernateDataAccessor(ISessionBuilder sessionBuilder)
        {
            _sessionBuilder = sessionBuilder;
            CurrentSession = _sessionBuilder.GetSession();
        }

        public ISession Session
        {
            get { return CurrentSession; }
        }
        public virtual IQueryable<T> CreateQuery()
        {
            CurrentSession.Flush();
            CurrentSession.SessionFactory.EvictQueries();
            return CurrentSession.Query<T>();
        }

        public virtual void Add(T entity)
        {
            CurrentSession.SaveOrUpdate(entity);
        }

        public virtual void Remove(IList<T> entities)
        {
            entities.ForEach(x => CurrentSession.Delete(x));
        }

        public virtual void Remove(T entity)
        {
            CurrentSession.Delete(entity);
        }

        public virtual IList<T> GetAll()
        {
            return (from item in CreateQuery() select item).ToList();
        }

        public virtual IList<T> GetAll(int pageSize, int pageNumber)
        {
            var query = CreateQuery().Skip(pageSize*pageNumber).Take(pageSize);
            return query.ToList();
        }

        public virtual T Get(object key)
        {
            return CurrentSession.Get<T>(key);
        }

        public virtual void Add(IList<T> entities)
        {
            foreach (T item in entities)
            {
                CurrentSession.SaveOrUpdate(item);
            }
        }

        public IList<T> ExecuteQuery(string query)
        {
            return CurrentSession.CreateQuery(query).List<T>();
        }

        public void Dispose()
        {
            _sessionBuilder.CloseSession();
        }

        public void BeginTransaction()
        {
            if(!CurrentSession.Transaction.IsActive)
                CurrentSession.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (CurrentSession.Transaction.IsActive) 
                CurrentSession.Transaction.Commit();
           
        }

        public void RollbackTransaction()
        {
            if (CurrentSession.Transaction.IsActive) 
                CurrentSession.Transaction.Rollback();
        }
    }
}