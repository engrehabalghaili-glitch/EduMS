using EduMS.Domain.Interfaces;
using EduMS.Infrastructure.Common.Persistence;
using EduMS.Infrastructure.Persistence.Seeding;
using EduMS.Application.Interfaces.Infrastructure;
using EduMS.Infrastructure.Services;
using EduMS.Infrastructure.Jobs;
using Hangfire;
using Hangfire.InMemory;
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

        // Repositories & UnitOfWork
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(EduMS.Application.Interfaces.Repositories.Common.IGenericRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<EduMS.Application.Interfaces.Repositories.Common.IUnitOfWork, UnitOfWork>();
        services.AddScoped<EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin.ISchoolRepository, EduMS.Infrastructure.M1_SchoolAdmin.SchoolRepository>();
        services.AddScoped<EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers.ISystemUserRepository, EduMS.Infrastructure.M8_AuthenticationUsers.SystemUserRepository>();
        services.AddScoped<EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers.IUserRoleAssignmentRepository, EduMS.Infrastructure.M8_AuthenticationUsers.UserRoleAssignmentRepository>();
        services.AddScoped<IEduMSDbInitializer, EduMSDbInitializer>();

        // Infrastructure Services
        services.AddScoped<IFileStorageService, FileStorageService>();
        services.AddScoped<ISystemHealthCheckJob, SystemHealthCheckJob>();
        services.AddScoped<EduMS.Application.Interfaces.Security.IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddHttpContextAccessor();
        services.AddScoped<EduMS.Application.Interfaces.Security.ICurrentUserService, EduMS.Infrastructure.Security.CurrentUserService>();
        services.AddScoped<EduMS.Application.Interfaces.CrossModule.IAcademicIntegrityChecker, EduMS.Infrastructure.CrossModule.AcademicIntegrityChecker>();

        // Custom RBAC Authorization Engine
        services.AddSingleton<Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider, EduMS.Infrastructure.Security.Authorization.PermissionAuthorizationPolicyProvider>();
        services.AddScoped<Microsoft.AspNetCore.Authorization.IAuthorizationHandler, EduMS.Infrastructure.Security.Authorization.PermissionAuthorizationHandler>();
        // Hangfire Background Jobs
        services.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseInMemoryStorage());
            
        services.AddHangfireServer();

        // Background Workers
        services.AddHostedService<EduMS.Infrastructure.Services.M7_CommunicationManagement.MessageQueueProcessorService>();

        return services;
    }
}



