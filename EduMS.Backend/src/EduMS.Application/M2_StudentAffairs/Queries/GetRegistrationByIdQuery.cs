using EduMS.Application.Common.CQRS;
using EduMS.Application.Registrations.DTOs;

namespace EduMS.Application.Registrations.Queries;

public record GetRegistrationByIdQuery(long Id) : IQuery<RegistrationDto?>;
