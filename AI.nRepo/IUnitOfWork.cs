using System;
using NHibernate;

namespace AI.nRepo
{
    public interface IUnitOfWork : IDisposable
    {
        void Start();
        void End();
        void Exception(Exception ex);
        ISession Session { get; }
    }
}