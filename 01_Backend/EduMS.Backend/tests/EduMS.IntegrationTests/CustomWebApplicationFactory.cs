using System;
using System.Data.Common;
using System.Linq;
using EduMS.Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EduMS.IntegrationTests
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptors = services.Where(
                    d => d.ServiceType == typeof(DbContextOptions<EduMSDbContext>) || 
                         d.ServiceType == typeof(DbContextOptions) ||
                         d.ServiceType.Name.Contains("DbContextOptions") ||
                         d.ServiceType.Namespace != null && d.ServiceType.Namespace.StartsWith("Microsoft.EntityFrameworkCore")).ToList();

                foreach (var descriptor in dbContextDescriptors)
                {
                    services.Remove(descriptor);
                }

                var dbConnectionDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbConnection));

                if (dbConnectionDescriptor != null)
                {
                    services.Remove(dbConnectionDescriptor);
                }

                // Create open SqliteConnection so in-memory database doesn't close immediately.
                // Using a unique Guid ensures isolation between factory instances.
                services.AddSingleton<DbConnection>(container =>
                {
                    var connection = new SqliteConnection($"DataSource=file:{Guid.NewGuid()}?mode=memory&cache=shared");
                    connection.Open();
                    return connection;
                });

                services.AddDbContext<EduMSDbContext>((container, options) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    options.UseSqlite(connection);
                });

                // Mock ICurrentUserService for tests to pass AuthorizationBehavior
                var currentUserDescriptors = services.Where(d => d.ServiceType == typeof(EduMS.Application.Interfaces.Security.ICurrentUserService)).ToList();
                foreach (var descriptor in currentUserDescriptors)
                {
                    services.Remove(descriptor);
                }

                services.AddScoped<EduMS.Application.Interfaces.Security.ICurrentUserService, TestCurrentUserService>();
            });
        }
    }

    public class TestCurrentUserService : EduMS.Application.Interfaces.Security.ICurrentUserService
    {
        public long? UserId => 1;
        public string? Email => "testadmin@edums.local";
        public string? Username => "testadmin";
        public long? TenantId => 1;
        public System.Collections.Generic.IEnumerable<string> Roles => new System.Collections.Generic.List<string> { "SYSTEM_ADMIN" };
        public bool IsAuthenticated => true;
    }
}
