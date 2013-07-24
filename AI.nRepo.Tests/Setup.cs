using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI.nRepo.Sharding;

namespace AI.nRepo.Tests
{
    public class Boot
    {
        public void Startup()
        {
             var masterConfig = AI.nRepo.Configure.As.ShardedNHibernate();
            masterConfig.CreateShard("Default1")
                .AddMappings(typeof(Customer).Assembly)
                .ConnectionString(ConfigurationManager.ConnectionStrings["Default1"].ConnectionString)
                .UpdateSchemaOnDebug();
            masterConfig.CreateShard("Default2")
                .AddMappings(typeof(Customer).Assembly)
                .ConnectionString(ConfigurationManager.ConnectionStrings["Default2"].ConnectionString)
                .UpdateSchemaOnDebug();

            AI.nRepo.Configure.With("Default", masterConfig).Start();
        }
    }
    public class Customer
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string State { get; set; }



        
    }

    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customer");
            Id(x => x.Id).GeneratedBy.Identity().Default(0);
            Map(x => x.Name, "[Name]");
            Map(x => x.State, "[State]");
            this.ShardingStrategy(x => 
            {
                if (x.State == "LA" || x.State == "TX" || x.State == "FL")
                    return "Default1";
                return "Default2";
            });
            this.ShardingLocator().AvailableShards("Default1", "Default2");
        }
    }

    public interface ICustomerRepo : IRepository<Customer>
    {

    }

    public class CustomerRepo : RepositoryBase<Customer>, ICustomerRepo
    {
        public CustomerRepo()
            : base("Default")
        {

        }
    }
}
