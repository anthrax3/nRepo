using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate.Cfg.Db;
namespace AI.nRepo.DbPlatforms
{
    public class InformixPlatform : IDatabasePlatform
    {

        public object AsNHibernateConfiguration(string connectionString)
        {
            return FluentNHibernate.Cfg.Db.IfxOdbcConfiguration.Informix.ConnectionString(connectionString);
        }
    }
}
