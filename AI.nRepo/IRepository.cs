using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI.nRepo.Configuration;


namespace AI.nRepo
{
    public interface IRepository<TAggregate> : IQueryable<TAggregate>//, IDisposable
        where TAggregate : class
    {
       
        void Add(TAggregate entity);

        void Remove(TAggregate entity);

        void Remove(IList<TAggregate> entities);

        TAggregate Get(object key);

        IList<TAggregate> GetAll();

        IList<TAggregate> GetAll(int pageSize, int pageNumber);

        void Add(IList<TAggregate> entities);

        IQueryable<TAggregate> CreateQuery();

        IDataAccessor<TAggregate> SetAccessor(string alias);

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
