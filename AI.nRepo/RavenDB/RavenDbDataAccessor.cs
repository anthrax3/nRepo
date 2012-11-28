using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Document;

namespace AI.nRepo.RavenDB
{
    public class RavenDbDataAccessor<T> : IDataAccessor<T>
    {
        private DocumentStore _documentStore;
        private IDocumentSession _documentSession;

        public RavenDbDataAccessor(DocumentStore documentStore)
        {
            this._documentStore = documentStore;
        }

        private void EnsureSession()
        {
            if (_documentSession == null)
                _documentSession = this._documentStore.OpenSession();
        }

        public void Add(T entity)
        {
            this.EnsureSession();
            this._documentSession.Store(entity);

        }

        public void Remove(T entity)
        {
            this.EnsureSession();
            this._documentSession.Delete(entity);

        }

        public void Remove(IList<T> entities)
        {
            foreach(var entity in entities)
                this.Remove(entity);
        }

        public T Get(object key)
        {
            this.EnsureSession();
            return this._documentSession.Load<T>(Convert.ToString(key));
        }

        public IList<T> GetAll()
        {
            var query = from entity in this.CreateQuery()
                        select entity;
            return query.ToList();
        }

        public IList<T> GetAll(int pageSize, int pageNumber)
        {
            var results = new List<T>();
            var query = from entity in this.CreateQuery()
                        select entity;
            query = query.Skip(pageSize * pageNumber).Take(pageSize);
            foreach(var item in query)
            {
                results.Add(item);
            }
            return results;
        }

        public void BeginTransaction()
        {
            this.EnsureSession();
        }

        public void CommitTransaction()
        {
            if(this._documentSession != null)
                this._documentSession.SaveChanges();
            this.CloseSession();
        }

        private void CloseSession()
        {
            if (this._documentSession == null)
                return;
            this._documentSession.Dispose();
            this._documentSession = null;
        }

        public void RollbackTransaction()
        {
            this.CloseSession();
        }

        public void Add(IList<T> entities)
        {
            foreach(var entity in entities)
                this.Add(entity);
        }

        public IQueryable<T> CreateQuery()
        {
            this.EnsureSession();
            return this._documentSession.Query<T>();
        }
    }
}
