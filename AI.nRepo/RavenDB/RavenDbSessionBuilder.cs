using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Document;

namespace AI.nRepo.RavenDB
{
    public class RavenDbSessionBuilder
    {
        public DocumentStore Session { get; private set; }
        public RavenDbSessionBuilder(string connString)
        {
            var store = new DocumentStore()
                            {
                                ConnectionStringName = connString
                            };
            this.Session = store;

        }


    }
}
