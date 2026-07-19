using EduMS.Application.M7_EmergencyManagement.DTOs.SafetySecurityReports;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M7_EmergencyManagement.Queries.SafetySecurityReports;

public class GetSafetySecurityReportByIdQuery : IRequest<SafetySecurityReportDto>
{
    public long Id { get; set; }
}

public class GetAllSafetySecurityReportsQuery : IRequest<IEnumerable<SafetySecurityReportDto>>
{
}