using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg.Db;

namespace AI.nRepo.DbPlatforms
{
    public class OraclePlatform
    {
        public class Server9Platform : IDatabasePlatform
        {

            public object AsNHibernateConfiguration(string connectionString)
            {
                return OracleDataClientConfiguration.Oracle9.ConnectionString(connectionString);
            }
        }

        public class Server10Platform : IDatabasePlatform
        {

            public object AsNHibernateConfiguration(string connectionString)
            {
                return OracleDataClientConfiguration.Oracle10.ConnectionString(connectionString);
            }
        }
    }
}
