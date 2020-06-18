using Orleans.TestingHost;
using RavenDB.Orleans.Test.GrainInterfaces;
using Xunit;

namespace Orleans.Persistence.RavenDB.Tests
{
    public class ScalarGrainPersistenceTests : IClassFixture<ClusterFixture>
    {
        private readonly TestCluster cluster;

        public ScalarGrainPersistenceTests(ClusterFixture fixture)
        {
            cluster = fixture.Cluster;
        }

        [Fact]
        public void CanWriteAndReadStringValueType()
        {
            var sut = cluster.GrainFactory.GetGrain<IScalarValuePersistentGrain<string>>(1);
        }
    }
}
