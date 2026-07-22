using EduMS.Application.M7_EmergencyManagement.DTOs.SafetySecurityReports;
using MediatR;

namespace EduMS.Application.M7_EmergencyManagement.Commands.SafetySecurityReports;

public class CreateSafetySecurityReportCommand : IRequest<long>
{
    public CreateSafetySecurityReportDto Dto { get; set; } = new();
}

public class UpdateSafetySecurityReportCommand : IRequest<bool>
{
    public UpdateSafetySecurityReportDto Dto { get; set; } = new();
}

public class DeleteSafetySecurityReportCommand : IRequest<bool>
{
    public long Id { get; set; }
}