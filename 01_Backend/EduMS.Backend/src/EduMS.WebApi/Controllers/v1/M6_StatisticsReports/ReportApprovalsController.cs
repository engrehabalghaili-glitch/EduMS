using EduMS.Application.Common.Responses;
using EduMS.Application.M6_StatisticsReports.Commands.ReportApprovals;
using EduMS.Application.M6_StatisticsReports.DTOs.ReportApprovals;
using EduMS.Application.M6_StatisticsReports.Queries.ReportApprovals;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M6_StatisticsReports;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ReportApprovalsController(MediatR.ISender sender) : ControllerBase

    
{
[HttpGet("calculate-live/{schoolId}")]
    public async Task<ActionResult<ApiResponse<string>>> CalculateLive(long schoolId)
    {
        var result = await sender.Send(new CalculateLiveReportApprovalQuery { SchoolId = schoolId });
        return Ok(ApiResponse<string>.Success(result));
    }

    [HttpGet("snapshot/{id}")]
    public async Task<ActionResult<ApiResponse<ReportApprovalDto>>> GetSnapshot(long id)
    {
        var result = await sender.Send(new GetReportApprovalSnapshotQuery { Id = id });
        return Ok(ApiResponse<ReportApprovalDto>.Success(result));
    }

    [HttpPost("draft")]
    public async Task<ActionResult<ApiResponse<long>>> Draft([FromBody] DraftReportApprovalCommand command)
    {
        var id = await sender.Send(command);
        return Ok(ApiResponse<long>.Success(id, "Draft created successfully."));
    }

    [HttpPost("approve")]
    public async Task<ActionResult<ApiResponse<bool>>> Approve([FromBody] ApproveReportApprovalCommand command)
    {
        var result = await sender.Send(command);
        return Ok(ApiResponse<bool>.Success(result, "Approved successfully."));
    }
}

