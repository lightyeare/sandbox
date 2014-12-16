using System.Data.SqlClient;
using RimDev.Sandbox;
using Xunit;

namespace RavenDb.Tests
{
    public class RavenDbGrainTests
    {
        [Fact]
        public void Can_register_with_sandbox_using_defaults()
        {
            var sandbox = new Sandbox().UseRavenDb();
            Assert.True(sandbox.Exists("RavenDb"));
        }

        [Fact]
        public void Can_register_with_sandbox_using_other_name()
        {
            var sandbox = new Sandbox().UseRavenDb(name: "Test");
            Assert.True(sandbox.Exists("Test"));
        }

        [Fact]
        public void Can_access_ravendb_from_grain()
        {
            using (var sandbox = new Sandbox().UseRavenDb().Play())
            {
                var sb = sandbox as dynamic;
                using (var session = sb.RavenDb.Instance.OpenSession())
                {
                    Assert.Equal(30, session.Advanced.MaxNumberOfRequestsPerSession);
                }
            }
        }
    }
}
