using System;
using RimDev.Sandbox;

namespace RavenDb
{
    public static class RavenDbSandboxExtensions
    {
        public static Sandbox UseRavenDb(this Sandbox sandbox, string name = "RavenDb", Action<dynamic, IRavenDbConfiguration> config = null)
        {
            var grain = new RavenDbGrain(name);
            sandbox.Add(grain);

            if (config != null)
                config((dynamic)sandbox, grain);

            return sandbox;
        }
    }
}