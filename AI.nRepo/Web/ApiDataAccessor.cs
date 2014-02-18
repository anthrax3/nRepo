using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo.Web
{
    public class ApiDataAccessor<T> : IDataAccessor<T>
    {
        private readonly IWebDataProvider _webDataProvider;
        public ApiDataAccessor(IWebDataProvider webDataProvider)
        {
            this._webDataProvider = webDataProvider;
        }

        public void Add(T entity)
        {
            _webDataProvider.Add(entity);
        }

        public void Remove(T entity)
        {
            _webDataProvider.Remove(entity);
        }

        public T Get(object key)
        {
            return _webDataProvider.Get<T>(key);
        }

        public IQueryable<T> CreateQuery()
        {
            return _webDataProvider.GetQueryable<T>();
        }

        public IList<T> GetAll(int pageSize, int pageNumber)
        {
            var query = CreateQuery().Skip(pageSize * pageNumber).Take(pageSize);
            return query.ToList();
        }

        public void Remove(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Remove(entity);
            }
        }
      
        public void Add(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Add(entity);
            }
        }

        public IList<T> GetAll()
        {
            return this.CreateQuery().ToList();
        }

        

        

        #region noop
        public IList<T> ExecuteQuery(string query)
        {
            return new List<T>();
        }

        public void Dispose()
        {
            
        }

        public void BeginTransaction()
        {

        }

        public void CommitTransaction()
        {

        }

        public void RollbackTransaction()
        {

        }
        #endregion





        public void SetSession(global::NHibernate.ISession session)
        {
            
        }

        public void SetIsolationLevel(System.Data.IsolationLevel level)
        {
        }
    }
}
