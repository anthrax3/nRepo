using NHibernate;

namespace AI.nRepo.NHibernate
{
    public class SessionBuilder : ISessionBuilder
    {
        private ISessionFactory _sessionFactory;
        private ISession _session;

        public SessionBuilder(SessionFactoryBuilder sessionFactoryBuilder)
        {
            _sessionFactory = sessionFactoryBuilder.SessionFactory;
        }

        public ISession GetSession()
        {
            if (_session == null)
            {
                _session = _sessionFactory.OpenSession();
                _session.FlushMode = FlushMode.Commit;
            }

            return _session;
        }

       

        public void CloseSession()
        {
            if (_session != null)
            {
                _session.Close();
                _session.Dispose();
                _session = null;
            }
            
        }
    }
}
