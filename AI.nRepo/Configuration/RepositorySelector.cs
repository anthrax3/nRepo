using AI.nRepo.CouchDB;
using AI.nRepo.EF;
using AI.nRepo.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI.nRepo.NHibernate;
using AI.nRepo.RavenDB;


namespace AI.nRepo.Configuration
{
    public class RepositorySelector : IRepositorySelector
    {


        public CouchDbConfiguration CouchDb()
        {
            return new CouchDbConfiguration();
        }

        public EntityFrameworkConfiguration EntityFramework()
        {
            return new EntityFrameworkConfiguration();
        }

        public NHibernateConfiguration NHibernate()
        {
            return new NHibernateConfiguration();
        }

        public RavenDbConfiguration RavenDb()
        {
            return new RavenDbConfiguration();
        }

        public MongoDbConfiguration MongoDB()
        {
            return new MongoDbConfiguration();
        }




        
    }
}
