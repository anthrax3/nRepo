using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Raven.Client.Document;

namespace AI.nRepo.RavenDB
{
    public class RavenDbDataAccessor<T> : IDataAccessor<T>, IUnitOfWorkItem
    {
        private readonly IDocumentStore _documentStore;
        private IDocumentSession _session;

        public RavenDbDataAccessor(IDocumentStore documentStore)
        {
            this._documentStore = documentStore;
        }

        private void EnsureSession()
        {
            if (_session == null)
                _session = this._documentStore.OpenSession();
        }

        public void Add(T entity)
        {
            this.EnsureSession();
            this._session.Store(entity);
        }

        public void Remove(T entity)
        {
            this.EnsureSession();
            this._session.Delete(entity);
        }

        public void Remove(IList<T> entities)
        {
            entities.ToList().ForEach(Remove);
        }

        public T Get(object key)
        {
            this.EnsureSession();
            return this._session.Load<T>(Convert.ToInt32(key));
        }

        public IList<T> GetAll()
        {
            var query = this.CreateQuery();
            return query.ToList();
        }

        public IList<T> GetAll(int pageSize, int pageNumber)
        {
            var query = this.CreateQuery().Skip(pageSize * pageNumber).Take(pageSize);
            return query.ToList();
        }

        private void CloseSession()
        {
            if (this._session == null)
                return;
            this._session.Dispose();
            this._session = null;
        }

        public void Add(IList<T> entities)
        {
            foreach (var entity in entities)
                this.Add(entity);
        }

        public IQueryable<T> CreateQuery()
        {
            this.EnsureSession();
            return this._session.Query<T>();
        }

        public IList<T> ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }


        public void BeginTransaction()
        {
            this.EnsureSession();
        }

        public void CommitTransaction()
        {
            if (this._session != null)
                this._session.SaveChanges();
            this.CloseSession();
        }

        public void RollbackTransaction()
        {
            this.CloseSession();
        }

        public void Dispose()
        {
            this.CloseSession();
        }
    }
}
