using System;
using System.Net.Http;
using EduMS.Infrastructure.Common.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EduMS.IntegrationTests
{
    public abstract class IntegrationTestBase<TEntryPoint, TDbContext> : IClassFixture<CustomWebApplicationFactory<TEntryPoint>>, IDisposable 
        where TEntryPoint : class 
        where TDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        protected readonly CustomWebApplicationFactory<TEntryPoint> Factory;
        protected readonly HttpClient Client;
        protected readonly IServiceScope Scope;
        protected readonly ISender Mediator;
        protected readonly TDbContext DbContext;

        protected IntegrationTestBase(CustomWebApplicationFactory<TEntryPoint> factory)
        {
            Factory = factory;
            Client = factory.CreateClient();
            Scope = factory.Services.CreateScope();
            Mediator = Scope.ServiceProvider.GetRequiredService<ISender>();
            DbContext = Scope.ServiceProvider.GetRequiredService<TDbContext>();
            
            DbContext.Database.EnsureCreated();
            
            if (DbContext is EduMS.Infrastructure.Common.Persistence.EduMSDbContext eduMsDbContext)
            {
                IntegrationTestSeeder.Seed(eduMsDbContext);
            }
        }

        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
            Scope.Dispose();
        }
    }
}
