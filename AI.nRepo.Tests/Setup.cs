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
            AI.nRepo.Configure.With(
                "Default",
                AI.nRepo.Configure.As.NHibernate()
                .AddMappings(typeof(Customer).Assembly)
                .ConnectionString(ConfigurationManager.ConnectionStrings["Default"].ConnectionString)
                .UpdateSchemaOnDebug()
                )
            .With(
                "Default2",
                AI.nRepo.Configure.As.NHibernate()
                .AddMappings(typeof(Customer).Assembly)
                .ConnectionString(ConfigurationManager.ConnectionStrings["Default2"].ConnectionString)
                .UpdateSchemaOnDebug()
            ).Start();
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
            this.ShardBy<Customer,int>(
                (c)=> 
                {
                    if (c.State == "LA")
                        return "Default";
                    return "Default2";
                }
                ,(key)=> {return "Default";});
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
