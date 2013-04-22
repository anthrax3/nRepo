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
    public interface IRepositorySelector
    {
        CouchDbConfiguration CouchDb();

        EntityFrameworkConfiguration EntityFramework();

        NHibernateConfiguration NHibernate();

        RavenDbConfiguration RavenDb();

        MongoDbConfiguration MongoDB();
    }
}
