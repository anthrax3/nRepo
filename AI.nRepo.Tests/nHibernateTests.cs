using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AI.nRepo.Tests
{
    [TestClass]
    public class nHibernateTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            new Boot().Startup();
            var c = new Customer();
            c.Name = "abc";
            c.State = "LA";
            var repo = new CustomerRepo();
            repo.BeginTransaction();
            repo.Add(c);
            repo.CommitTransaction();

            var c2 = new Customer();
            c2.State = "TX";
            c2.Name = "def";
            repo.BeginTransaction();
            repo.Add(c2);
            repo.CommitTransaction();
        }
    }
}
