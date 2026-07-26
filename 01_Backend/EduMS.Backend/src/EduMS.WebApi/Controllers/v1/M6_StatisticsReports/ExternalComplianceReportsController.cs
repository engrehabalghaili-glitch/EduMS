using EduMS.Application.Common.Responses;
using EduMS.Application.M6_StatisticsReports.Commands.ExternalComplianceReports;
using EduMS.Application.M6_StatisticsReports.DTOs.ExternalComplianceReports;
using EduMS.Application.M6_StatisticsReports.Queries.ExternalComplianceReports;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M6_StatisticsReports;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ExternalComplianceReportsController(MediatR.ISender sender) : ControllerBase

    
{
[HttpGet("calculate-live/{schoolId}")]
    public async Task<ActionResult<ApiResponse<string>>> CalculateLive(long schoolId)
    {
        var result = await sender.Send(new CalculateLiveExternalComplianceReportQuery { SchoolId = schoolId });
        return Ok(ApiResponse<string>.Success(result));
    }

    [HttpGet("snapshot/{id}")]
    public async Task<ActionResult<ApiResponse<ExternalComplianceReportDto>>> GetSnapshot(long id)
    {
        var result = await sender.Send(new GetExternalComplianceReportSnapshotQuery { Id = id });
        return Ok(ApiResponse<ExternalComplianceReportDto>.Success(result));
    }

    [HttpPost("draft")]
    public async Task<ActionResult<ApiResponse<long>>> Draft([FromBody] DraftExternalComplianceReportCommand command)
    {
        var id = await sender.Send(command);
        return Ok(ApiResponse<long>.Success(id, "Draft created successfully."));
    }

    [HttpPost("approve")]
    public async Task<ActionResult<ApiResponse<bool>>> Approve([FromBody] ApproveExternalComplianceReportCommand command)
    {
        var result = await sender.Send(command);
        return Ok(ApiResponse<bool>.Success(result, "Approved successfully."));
    }
}

