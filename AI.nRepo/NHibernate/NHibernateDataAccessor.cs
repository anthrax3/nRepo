using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using NHibernate;
using AI.nRepo.Configuration;


namespace AI.nRepo
{
    public class NHibernateDataAccessor<T> : IDataAccessor<T>
        
    {

        private readonly ISessionBuilder _sessionBuilder;
        protected ISession CurrentSession;

        public NHibernateDataAccessor(ISessionBuilder sessionBuilder)
        {
            this._sessionBuilder = sessionBuilder;
            this.CurrentSession = this._sessionBuilder.GetSession();
        }

        public virtual IQueryable<T> CreateQuery()
        {
            return this.CurrentSession.Query<T>();
        }

        

        public virtual void Add(T entity)
        {
            this.CurrentSession.SaveOrUpdate(entity);
            
        }

        public virtual void Remove(IList<T> entities)
        {
            foreach (var item in entities)
            {
                this.CurrentSession.Delete(item);
            }
        }

        public virtual void Remove(T entity)
        {
           this.CurrentSession.Delete(entity);
        }

        public virtual IList<T> GetAll()
        {
            return (from item in this.CreateQuery() select item).ToList();
        }

        public virtual IList<T> GetAll(int pageSize, int pageNumber)
        {
            var query = this.CreateQuery();
            query = (from x in query select x);
            query = query.Skip(pageSize * pageNumber).Take(pageSize);
            List<T> list = new List<T>();
            foreach (var item in query)
            {
                list.Add((T)item);
            }
            return list;
        }

        public virtual T Get(object key)
        {
            return this.CurrentSession.Get<T>(key);
        }

        public virtual void Add(IList<T> entities)
        {
            foreach (var item in entities)
            {
                this.CurrentSession.SaveOrUpdate(item);
            }
        }

        public void BeginTransaction()
        {
            this.CurrentSession.BeginTransaction();
        }

        public void CommitTransaction()
        {
            this.CurrentSession.Transaction.Commit();
        }

        public void RollbackTransaction()
        {
            this.CurrentSession.Transaction.Rollback();
        }





        public IList<T> ExecuteQuery(string query)
        {
            return this.CurrentSession.CreateQuery(query).List<T>();
        }

        public void Dispose()
        {
            this._sessionBuilder.CloseSession();
        }
    }
}
