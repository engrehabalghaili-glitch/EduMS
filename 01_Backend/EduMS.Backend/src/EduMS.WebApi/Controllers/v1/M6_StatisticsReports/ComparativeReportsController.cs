using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M6_StatisticsReports.Commands.ComparativeReports;
using EduMS.Application.M6_StatisticsReports.DTOs.ComparativeReports;
using EduMS.Application.M6_StatisticsReports.Queries.ComparativeReports;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M6_StatisticsReports;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ComparativeReportsController(MediatR.ISender sender) : ControllerBase

    
{
[HttpGet("calculate-live/{schoolId}")]
    public async Task<ActionResult<ApiResponse<string>>> CalculateLive(long schoolId)
    {
        var result = await sender.Send(new CalculateLiveComparativeReportQuery { SchoolId = schoolId });
        return Ok(ApiResponse<string>.Success(result));
    }

    [HttpGet("snapshot/{id}")]
    public async Task<ActionResult<ApiResponse<ComparativeReportDto>>> GetSnapshot(long id)
    {
        var result = await sender.Send(new GetComparativeReportSnapshotQuery { Id = id });
        return Ok(ApiResponse<ComparativeReportDto>.Success(result));
    }

    [HttpPost("draft")]
    public async Task<ActionResult<ApiResponse<long>>> Draft([FromBody] DraftComparativeReportCommand command)
    {
        var id = await sender.Send(command);
        return Ok(ApiResponse<long>.Success(id, "Draft created successfully."));
    }

    [HttpPost("approve")]
    public async Task<ActionResult<ApiResponse<bool>>> Approve([FromBody] ApproveComparativeReportCommand command)
    {
        var result = await sender.Send(command);
        return Ok(ApiResponse<bool>.Success(result, "Approved successfully."));
    }
}


