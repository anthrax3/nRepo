using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AI.nRepo.Configuration
{
    public interface IRepositoryConfiguration
    {
        IRepositoryConfiguration Start();
        IDataAccessor<T> Create<T>() where T : class;
    }
}
