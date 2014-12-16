using System;
using System.Diagnostics;
using Raven.Client.Embedded;
using RimDev.Sandbox;

namespace RavenDb
{
    [DebuggerDisplay("RavenDb Grain <{Name}>")]
    public class RavenDbGrain : IGrain, IRavenDbConfiguration
    {
        public RavenDbGrain(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            
            Name = name;
        }

        public string Name { get; protected set; }
        public string DatabaseName { get; protected set; }

        public EmbeddableDocumentStore Instance { get; protected set; }

        public void Dispose()
        {
            if (Instance != null)
                Instance.Dispose();
        }

        public void Setup(Sandbox sandbox)
        {
            var location = sandbox.CreateGrainDirectory(this);
            Instance = new EmbeddableDocumentStore{DataDirectory = location, DefaultDatabase = DatabaseName};
            Instance.Initialize();
        }

        public IRavenDbConfiguration WithDatabaseName(string databaseName)
        {
            if (databaseName == null) throw new ArgumentNullException("databaseName");

            DatabaseName = databaseName;
            return this;
        }

    }
}