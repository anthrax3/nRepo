using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Raven.Client.Document;

namespace AI.nRepo.Raven
{
    public class RavenDbSessionBuilder
    {
        public IDocumentStore Session { get; private set; }
        public RavenDbSessionBuilder(string connString, string databaseName)
        {
            var documentStore = new DocumentStore
                {
                    Url = connString,
                    DefaultDatabase = databaseName
                }.Initialize();
            this.Session = documentStore;
        }
    }
}
