using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate.Cfg.Db;

namespace AI.nRepo.DbPlatforms
{
    public class MySqlPlatform : IDatabasePlatform
    {
        public object AsNHibernateConfiguration(string connectionString)
        {
            return MySQLConfiguration.Standard.ConnectionString(connectionString);
        }
    }
}
