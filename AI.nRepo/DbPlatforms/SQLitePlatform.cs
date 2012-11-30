using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg.Db;

namespace AI.nRepo.DbPlatforms
{
    public class SQLitePlatform 
    {
        public class InMemory : IDatabasePlatform
        {

            public object AsNHibernateConfiguration(string connectionString)
            {
                return SQLiteConfiguration.Standard.InMemory();
            }
        }

        public class FileBased : IDatabasePlatform
        {

            public object AsNHibernateConfiguration(string connectionString)
            {
                return SQLiteConfiguration.Standard.UsingFile(connectionString);
            }
        }
        
    }
}
