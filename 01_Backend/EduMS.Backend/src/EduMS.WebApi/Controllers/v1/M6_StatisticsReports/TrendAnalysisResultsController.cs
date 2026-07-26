using EduMS.Application.Common.Responses;
using EduMS.Application.M6_StatisticsReports.Commands.TrendAnalysisResults;
using EduMS.Application.M6_StatisticsReports.DTOs.TrendAnalysisResults;
using EduMS.Application.M6_StatisticsReports.Queries.TrendAnalysisResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M6_StatisticsReports;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class TrendAnalysisResultsController(MediatR.ISender sender) : ControllerBase

    
{
[HttpGet("calculate-live/{schoolId}")]
    public async Task<ActionResult<ApiResponse<string>>> CalculateLive(long schoolId)
    {
        var result = await sender.Send(new CalculateLiveTrendAnalysisResultQuery { SchoolId = schoolId });
        return Ok(ApiResponse<string>.Success(result));
    }

    [HttpGet("snapshot/{id}")]
    public async Task<ActionResult<ApiResponse<TrendAnalysisResultDto>>> GetSnapshot(long id)
    {
        var result = await sender.Send(new GetTrendAnalysisResultSnapshotQuery { Id = id });
        return Ok(ApiResponse<TrendAnalysisResultDto>.Success(result));
    }

    [HttpPost("draft")]
    public async Task<ActionResult<ApiResponse<long>>> Draft([FromBody] DraftTrendAnalysisResultCommand command)
    {
        var id = await sender.Send(command);
        return Ok(ApiResponse<long>.Success(id, "Draft created successfully."));
    }

    [HttpPost("approve")]
    public async Task<ActionResult<ApiResponse<bool>>> Approve([FromBody] ApproveTrendAnalysisResultCommand command)
    {
        var result = await sender.Send(command);
        return Ok(ApiResponse<bool>.Success(result, "Approved successfully."));
    }
}

