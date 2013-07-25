using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo.DbPlatforms
{
    public class InformixSqlLinkPlatform : IDatabasePlatform
    {
        public object AsNHibernateConfiguration(string connectionString)
        {
            return FluentNHibernate.Cfg.Db.IfxSQLIConfiguration.Informix0940.ConnectionString(connectionString);
        }
    }
}
