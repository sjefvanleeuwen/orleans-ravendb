using Microsoft.Extensions.Options;
using Orleans.Hosting;
using Orleans.TestingHost;

namespace Orleans.Persistence.RavenDB.Tests
{
    public class TestSiloConfigurator : ISiloConfigurator
    {
        public void Configure(ISiloBuilder siloBuilder)
        {
            siloBuilder
                .AddRavenDBGrainStorage(name: "unit-test");
        }
    }
}
