using NHibernate;

namespace AI.nRepo.NHibernate
{
    public interface ISessionBuilder
    {
        ISession GetSession();

        void CloseSession();
    }
}
