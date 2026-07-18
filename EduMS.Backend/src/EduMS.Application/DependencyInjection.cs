using System.Reflection;
using EduMS.Application.Common.CQRS;
using EduMS.Application.Common.Validation;
using EduMS.Application.Locks.Commands;
using EduMS.Application.Locks.Queries;
using EduMS.Application.Persons.Commands;
using EduMS.Application.Persons.Validators;
using EduMS.Application.Registrations.Commands;
using EduMS.Application.Registrations.Queries;
using EduMS.Application.Registrations.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EduMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        // 1. Register MediatR & Global Validation Behavior
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        // 2. Register FluentValidation Validators
        services.AddValidatorsFromAssembly(assembly);

        // 3. Register AutoMapper Profiles
        services.AddAutoMapper(assembly);

        // 4. Register Custom CQRS Dispatcher & Pipeline Behavior (Backward Compatibility)
        services.AddScoped<IDispatcher, Dispatcher>();
        services.AddScoped(typeof(EduMS.Application.Common.CQRS.IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<ICommandHandler<CreatePersonCommand, long>, CreatePersonCommandHandler>();
        services.AddScoped<ICommandHandler<ApplyAcademicLockCommand, long>, ApplyAcademicLockCommandHandler>();
        services.AddScoped<IQueryHandler<CheckAcademicLockQuery, bool>, CheckAcademicLockQueryHandler>();

        // Registration Handlers
        services.AddScoped<ICommandHandler<CreateRegistrationCommand, long>, CreateRegistrationCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateRegistrationCommand, bool>, UpdateRegistrationCommandHandler>();
        services.AddScoped<IQueryHandler<GetRegistrationByIdQuery, EduMS.Application.Registrations.DTOs.RegistrationDto?>, GetRegistrationByIdQueryHandler>();

        services.AddScoped<EduMS.Application.Common.Validation.IValidator<CreatePersonCommand>, CreatePersonCommandValidator>();
        services.AddScoped<EduMS.Application.Common.Validation.IValidator<CreateRegistrationCommand>, CreateRegistrationCommandValidator>();
        services.AddScoped<EduMS.Application.Common.Validation.IValidator<UpdateRegistrationCommand>, UpdateRegistrationCommandValidator>();

        return services;
    }
}

