using EduMS.Application.Common.CQRS;
using EduMS.Application.Common.Validation;
using EduMS.Application.Locks.Commands;
using EduMS.Application.Locks.Queries;
using EduMS.Application.Persons.Commands;
using EduMS.Application.Persons.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace EduMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IDispatcher, Dispatcher>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<ICommandHandler<CreatePersonCommand, long>, CreatePersonCommandHandler>();
        services.AddScoped<ICommandHandler<ApplyAcademicLockCommand, long>, ApplyAcademicLockCommandHandler>();
        services.AddScoped<IQueryHandler<CheckAcademicLockQuery, bool>, CheckAcademicLockQueryHandler>();

        services.AddScoped<IValidator<CreatePersonCommand>, CreatePersonCommandValidator>();

        return services;
    }
}
