using EduMS.Domain.Interfaces;
using EduMS.Infrastructure.Common.Persistence;
using EduMS.Infrastructure.Persistence.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduMS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
                               ?? "User Id=EDUMS_USER;Password=EduMsPass123;Data Source=localhost:1521/orclpdb;";

        services.AddDbContext<EduMSDbContext>(options =>
        {
            options.UseOracle(connectionString, oracleOptions =>
            {
                oracleOptions.MigrationsAssembly("EduMS.Infrastructure");
                oracleOptions.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion19);
            });
        });

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(EduMS.Application.Interfaces.Repositories.Common.IGenericRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<EduMS.Application.Interfaces.Repositories.Common.IUnitOfWork, UnitOfWork>();
        services.AddScoped<EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin.ISchoolRepository, EduMS.Infrastructure.M1_SchoolAdmin.SchoolRepository>();
        services.AddScoped<IEduMSDbInitializer, EduMSDbInitializer>();


        return services;
    }
}
