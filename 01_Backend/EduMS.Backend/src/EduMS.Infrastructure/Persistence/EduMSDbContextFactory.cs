using EduMS.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EduMS.Infrastructure.Persistence;

/// <summary>
/// Design-time factory for creating EduMSDbContext instances specifically for EF Core CLI migrations generation.
/// Configured explicitly with Oracle 19c provider and migrations assembly targeting EduMS.Infrastructure.
/// </summary>
public class EduMSDbContextFactory : IDesignTimeDbContextFactory<EduMSDbContext>
{
    public EduMSDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EduMSDbContext>();
        
        // Target Oracle 19c connection string verified for local container deployment
        optionsBuilder.UseOracle(
            "User Id=EDUMS_USER;Password=EduMsPass123;Data Source=localhost:1521/orclpdb;",
            oracleOptions =>
            {
                oracleOptions.MigrationsAssembly("EduMS.Infrastructure");
                oracleOptions.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion19);
            });

        return new EduMSDbContext(optionsBuilder.Options, new DesignTimeCurrentUserService());
    }

    private class DesignTimeCurrentUserService : EduMS.Application.Interfaces.Security.ICurrentUserService
    {
        public long? UserId => null;
        public string? Username => null;
        public long? TenantId => null;
        public bool IsAuthenticated => false;
        public System.Collections.Generic.IEnumerable<string> Roles => System.Linq.Enumerable.Empty<string>();
    }
}
