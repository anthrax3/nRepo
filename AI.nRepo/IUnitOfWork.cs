using System;

namespace AI.nRepo
{
    public interface IUnitOfWork : IDisposable
    {
        void AddWorkItem(IUnitOfWorkItem workItem);
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
    }
}