using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo.Configuration
{
    public interface IRepositoryConfiguration
    {
        void Start();

        IDataAccessor<T> Create<T>();
    }
}
