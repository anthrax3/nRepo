using System;

namespace AI.nRepo
{
    public interface IUnitOfWorkItem : IDisposable
    {
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
    }
}