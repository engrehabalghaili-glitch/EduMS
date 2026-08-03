using EduMS.Application.M3_EmployeeManagement.DTOs.AppointmentDecisions;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.AppointmentDecisions;

public class CreateAppointmentDecisionCommand : IRequest<long>
{
    public CreateAppointmentDecisionDto Dto { get; set; } = new();
}

public class UpdateAppointmentDecisionCommand : IRequest<bool>
{
    public UpdateAppointmentDecisionDto Dto { get; set; } = new();
}

public class DeleteAppointmentDecisionCommand : IRequest<bool>
{
    public long Id { get; set; }
}