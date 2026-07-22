using EduMS.Application.Common.Responses;
using EduMS.Application.M6_StatisticsReports.Commands.GapAnalysisReports;
using EduMS.Application.M6_StatisticsReports.DTOs.GapAnalysisReports;
using EduMS.Application.M6_StatisticsReports.Queries.GapAnalysisReports;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M6_StatisticsReports;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class GapAnalysisReportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public GapAnalysisReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("calculate-live/{schoolId}")]
    public async Task<ActionResult<ApiResponse<string>>> CalculateLive(long schoolId)
    {
        var result = await _mediator.Send(new CalculateLiveGapAnalysisReportQuery { SchoolId = schoolId });
        return Ok(ApiResponse<string>.Success(result));
    }

    [HttpGet("snapshot/{id}")]
    public async Task<ActionResult<ApiResponse<GapAnalysisReportDto>>> GetSnapshot(long id)
    {
        var result = await _mediator.Send(new GetGapAnalysisReportSnapshotQuery { Id = id });
        return Ok(ApiResponse<GapAnalysisReportDto>.Success(result));
    }

    [HttpPost("draft")]
    public async Task<ActionResult<ApiResponse<long>>> Draft([FromBody] DraftGapAnalysisReportCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(ApiResponse<long>.Success(id, "Draft created successfully."));
    }

    [HttpPost("approve")]
    public async Task<ActionResult<ApiResponse<bool>>> Approve([FromBody] ApproveGapAnalysisReportCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(ApiResponse<bool>.Success(result, "Approved successfully."));
    }
}