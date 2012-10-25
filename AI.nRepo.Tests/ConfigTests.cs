using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AI.nRepo.Configuration;
using System.Reflection;

namespace AI.nRepo.Tests
{
    [TestClass]
    public class ConfigTests
    {
        [TestMethod]
        public void configure()
        {
            Configure.As.NHibernate()
                .ConnectionString("myConnString")
                .UpdateSchemaOnDebug()
                .AddMappings(typeof(ConfigTests).Assembly)
                .Start();
                
        }
    }
}
