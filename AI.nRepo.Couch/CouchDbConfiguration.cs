using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AI.nRepo.Couch
{
    public class CouchDbConfiguration : IRepositoryConfiguration
    {
        public IRepositoryConfiguration Start()
        {
            return this;
        }

        public IDataAccessor<T> Create<T>()
            where T: class
        {
            return new CouchDbDataAccessor<T>();
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
