using Helmes.Shared.Repository;
using Helmes.WebApi.EndPoint;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Helmes.WebApiTests
{
    class TaskApplication : WebApplicationFactory<UserEndpointDefinition>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.AddSingleton(sp =>
                {
                    // Replace SQLite with the in memory provider for tests
                    return new DbContextOptionsBuilder<DatabaseContext>()
                                .UseInMemoryDatabase("Tests", root)
                                .UseApplicationServiceProvider(sp)
                                .Options;
                });
            });

            return base.CreateHost(builder);
        }
    }
}
