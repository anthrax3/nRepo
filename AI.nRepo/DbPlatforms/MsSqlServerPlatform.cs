﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate.Cfg.Db;

namespace AI.nRepo.DbPlatforms
{
    public class MsSqlServer 
    {
        public class Server2000Platform : IDatabasePlatform
        {
            public object AsNHibernateConfiguration(string connectionString)
            {
                return MsSqlConfiguration.MsSql2000.ConnectionString(connectionString);
            }
        }

        public class Server2005Platform : IDatabasePlatform
        {
            public object AsNHibernateConfiguration(string connectionString)
            {
                return MsSqlConfiguration.MsSql2005.ConnectionString(connectionString);
            }
        }

        public class Server2008Platform : IDatabasePlatform
        {

            public object AsNHibernateConfiguration(string connectionString)
            {
                return MsSqlConfiguration.MsSql2008.ConnectionString(connectionString);
            }
        }

        public class Server2012Platform : IDatabasePlatform
        {

            public object AsNHibernateConfiguration(string connectionString)
            {
                return MsSqlConfiguration.MsSql2008.ConnectionString(connectionString);
            }
        }

        public class Server7Platform : IDatabasePlatform
        {

            public object AsNHibernateConfiguration(string connectionString)
            {
                return MsSqlConfiguration.MsSql7.ConnectionString(connectionString);
            }
        }


    }
}
