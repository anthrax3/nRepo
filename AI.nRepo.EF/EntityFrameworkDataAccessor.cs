using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AI.nRepo.EntityFramework
{

    
    public class EntityFrameworkDataAccessor<T> : IDataAccessor<T>
    where T : class
    {
        private class EFDbContext : DbContext
        {
            IList<IConfigureATypeForPersistence> _configurations;
            public EFDbContext(string connectionString, IList<IConfigureATypeForPersistence> configurations)
                :base(connectionString)
            {
                _configurations = configurations;
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                _configurations.ToList().ForEach(x =>
                {
                    x.Configure(modelBuilder);
                });
                
                base.OnModelCreating(modelBuilder);
            }
        }
        
        string _connectionString;
        DbContext _context;
        List<IConfigureATypeForPersistence> _configurations;
        public EntityFrameworkDataAccessor(string connectionString, IList<IConfigureATypeForPersistence> configurations)
        {
            _configurations = configurations.ToList();
            if (String.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection String cannot be null or empty");
            _connectionString = connectionString;
            _context = new EFDbContext(_connectionString,_configurations);
            _context.Database.Initialize(false);
        }

        

        public void SetIsolationLevel(System.Data.IsolationLevel level)
        {
            //no-op
        }

        public void Add(T entity)
        {
            var set = _context.Set<T>();
            set.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            var set = _context.Set<T>();
            set.Remove(entity);
            _context.SaveChanges();
        }

        public void Remove(IList<T> entities)
        {
            entities.ToList().ForEach(x => Remove(x));
        }

        public T Get(object key)
        {

            var set = _context.Set<T>();
            return set.Find(key);
            
        }

        public IList<T> GetAll()
        {
            return this.CreateQuery().ToList();
        }

        public IList<T> GetAll(int pageSize, int pageNumber)
        {
            var set = _context.Set<T>();
            return set.GetPage(pageNumber, pageSize)
                .ToList();
        }

        public void BeginTransaction()
        {
            //no-op
        }

        public void CommitTransaction()
        {
            _context.SaveChanges();
        }

        public void RollbackTransaction()
        {
            //no-op
        }

        public void Add(IList<T> entities)
        {
            entities.ToList().ForEach(x => Add(x));
        }

        public IQueryable<T> CreateQuery()
        {
            return _context.Set<T>();
        }

        public IList<T> ExecuteQuery(string query)
        {
            object[] @params = new Object[0];
            return _context.Database
                        .SqlQuery<T>(query,@params)
                        .ToList();
        }

        public void Dispose()
        {
            if (null == _context)
                return;
            _context.Dispose();
            _context = null;
        }
    }
}
