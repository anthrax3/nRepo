using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo.MongoDB
{
    public class MongoDbConfiguration : IRepositoryConfiguration
    {
        public void Start()
        {
            throw new NotImplementedException();
        }

        public IDataAccessor<T> Create<T>()
        {
            return new MongoDbDataAccessor<T>();
        }
    }
}
