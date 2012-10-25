using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace AI.nRepo
{
    public interface ISessionBuilder
    {
        ISession GetSession();

        void CloseSession();
    }
}
