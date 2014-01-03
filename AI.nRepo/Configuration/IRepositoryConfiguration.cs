using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AI.nRepo.Configuration
{
    public interface IRepositoryConfiguration
    {
        IRepositoryConfiguration Start();
        IUnitOfWork GetCurrentUnitOfWork();
        void CloseUnitOfWork();
        IDataAccessor<T> Create<T>();
    }
}
