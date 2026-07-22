using EduMS.Application.Common.Responses;
using EduMS.Application.M6_StatisticsReports.Commands.SchoolStatisticsDrafts;
using EduMS.Application.M6_StatisticsReports.DTOs.SchoolStatisticsDrafts;
using EduMS.Application.M6_StatisticsReports.Queries.SchoolStatisticsDrafts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M6_StatisticsReports;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolStatisticsDraftsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SchoolStatisticsDraftsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("calculate-live/{schoolId}")]
    public async Task<ActionResult<ApiResponse<string>>> CalculateLive(long schoolId)
    {
        var result = await _mediator.Send(new CalculateLiveSchoolStatisticsDraftQuery { SchoolId = schoolId });
        return Ok(ApiResponse<string>.Success(result));
    }

    [HttpGet("snapshot/{id}")]
    public async Task<ActionResult<ApiResponse<SchoolStatisticsDraftDto>>> GetSnapshot(long id)
    {
        var result = await _mediator.Send(new GetSchoolStatisticsDraftSnapshotQuery { Id = id });
        return Ok(ApiResponse<SchoolStatisticsDraftDto>.Success(result));
    }

    [HttpPost("draft")]
    public async Task<ActionResult<ApiResponse<long>>> Draft([FromBody] DraftSchoolStatisticsDraftCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(ApiResponse<long>.Success(id, "Draft created successfully."));
    }

    [HttpPost("approve")]
    public async Task<ActionResult<ApiResponse<bool>>> Approve([FromBody] ApproveSchoolStatisticsDraftCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(ApiResponse<bool>.Success(result, "Approved successfully."));
    }
}