using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo.DbPlatforms
{
    public class InformixDRDAPlatform : IDatabasePlatform
    {
        public object AsNHibernateConfiguration(string connectionString)
        {
            return FluentNHibernate.Cfg.Db.IfxDRDAConfiguration.Informix.ConnectionString(connectionString);
        }
    }

    
}
