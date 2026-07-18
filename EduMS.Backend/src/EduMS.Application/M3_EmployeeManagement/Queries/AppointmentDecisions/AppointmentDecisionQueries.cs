using EduMS.Application.M3_EmployeeManagement.DTOs.AppointmentDecisions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.AppointmentDecisions;

public class GetAppointmentDecisionByIdQuery : IRequest<AppointmentDecisionDto>
{
    public long Id { get; set; }
}

public class GetAllAppointmentDecisionsQuery : IRequest<IEnumerable<AppointmentDecisionDto>>
{
}