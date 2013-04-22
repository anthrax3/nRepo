using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate.Cfg.Db;

namespace AI.nRepo.DbPlatforms
{
    public class PostgresPlatform : IDatabasePlatform
    {
        public object AsNHibernateConfiguration(string connectionString)
        {
            return PostgreSQLConfiguration.Standard.ConnectionString(connectionString);
        }
    }
}
