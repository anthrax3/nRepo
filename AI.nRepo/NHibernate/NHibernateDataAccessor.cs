using System.Collections.Generic;
using System.Linq;
using AI.nRepo.Configuration;
using NHibernate;
using NHibernate.Linq;

namespace AI.nRepo.NHibernate
{
    public class NHibernateDataAccessor<T> : IDataAccessor<T>
    {
        private readonly IUnitOfWork _unitOfWork;
       

        public NHibernateDataAccessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ISession Session
        {
            get { return _unitOfWork.Session; }
        }
        public virtual IQueryable<T> CreateQuery()
        {
            Session.Flush();
            Session.SessionFactory.EvictQueries();
            return Session.Query<T>();
        }

        public virtual void Add(T entity)
        {
            Session.SaveOrUpdate(entity);
        }

        public virtual void Remove(IList<T> entities)
        {
            entities.ForEach(x => Session.Delete(x));
        }

        public virtual void Remove(T entity)
        {
            Session.Delete(entity);
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
            return Session.Get<T>(key);
        }

        public virtual void Add(IList<T> entities)
        {
            foreach (T item in entities)
            {
                Session.SaveOrUpdate(item);
            }
        }

        public IList<T> ExecuteQuery(string query)
        {
            return Session.CreateQuery(query).List<T>();
        }

        public void Dispose()
        {
            _unitOfWork.End();
        }

        public void BeginTransaction()
        {
            if (!Session.Transaction.IsActive)
                Session.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (Session.Transaction.IsActive)
                Session.Transaction.Commit();
           
        }

        public void RollbackTransaction()
        {
            if (Session.Transaction.IsActive)
                Session.Transaction.Rollback();
        }


        
    }
}