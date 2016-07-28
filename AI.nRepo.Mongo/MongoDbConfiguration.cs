using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AI.nRepo.Mongo
{
    public class MongoDbConfiguration : IRepositoryConfiguration
    {
        public IRepositoryConfiguration Start()
        {
            return this;
        }

        public IDataAccessor<T> Create<T>()
        {
            return new MongoDbDataAccessor<T>();
        }

        public IUnitOfWork GetCurrentUnitOfWork()
        {
            throw new NotImplementedException();
        }

        public void CloseUnitOfWork()
        {
            throw new NotImplementedException();
        }
    }
}
