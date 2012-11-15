nRepo
=====

.NET Framework for Data Access layers using the repository pattern.

Example usage:

(Configuration and Setup with StructureMap) *similarly you can make the single registration with any IoC of your choosing*


*In our implementation, we wanted to leave the framework open to utilization with any IoC container. As such, you only need to perform two simple steps to setup your application. Below is an example, using StructureMap*

<code> 

     //Step 1: Register and start nRepo

     var repoConfig = AI.nRepo.Configure.As

     .NHibernate()

     .AddMappings(typeof(GameMap).Assembly)

     .ConnectionString(ConfigurationManager.ConnectionStrings["PokerDB"].ConnectionString)

     .UpdateSchemaOnDebug()

     .Start();

     //Step 2: Register IRepositoryConfiguration in the IoC
     ObjectFactory.Configure(x=>

     {

      x.For<IRepositoryConfiguration>().Use(repoConfig);

     });

</code>