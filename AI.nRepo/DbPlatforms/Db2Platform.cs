using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate.Cfg.Db;

namespace AI.nRepo.DbPlatforms
{
    public class Db2Platform : IDatabasePlatform
    {
        public object AsNHibernateConfiguration(string connectionString)
        {
            return DB2Configuration.Standard.ConnectionString(connectionString);
        }
    }
}
