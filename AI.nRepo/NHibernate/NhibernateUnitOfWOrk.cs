using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace AI.nRepo.NHibernate
{
    public class NhibernateUnitOfWork : IUnitOfWork
    {
        private ISessionBuilder _sessionBuilder;
        public NhibernateUnitOfWork(ISessionBuilder sessionBuilder)
        {
            _sessionBuilder = sessionBuilder;
            this.UnitOfWorkId = Guid.NewGuid();
        }

        public ISession Session { get { return _sessionBuilder.GetSession(); } }

        public Guid UnitOfWorkId { get; private set; }

        public void Start()
        {
            if (!_sessionBuilder.GetSession().Transaction.IsActive)
                _sessionBuilder.GetSession().BeginTransaction();
        }

        public void End()
        {
            if (_sessionBuilder.GetSession().Transaction.IsActive)
                _sessionBuilder.GetSession().Transaction.Commit();
            _sessionBuilder.CloseSession();
        }

        public void Exception(Exception ex)
        {
            if (_sessionBuilder.GetSession().Transaction.IsActive)
                _sessionBuilder.GetSession().Transaction.Rollback();
        }



        public void Dispose()
        {
            _sessionBuilder.CloseSession();
        }
    }
}
