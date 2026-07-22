using EduMS.Application.Common.Responses;
using EduMS.Application.M6_StatisticsReports.Commands.StatisticsReportsArchives;
using EduMS.Application.M6_StatisticsReports.DTOs.StatisticsReportsArchives;
using EduMS.Application.M6_StatisticsReports.Queries.StatisticsReportsArchives;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M6_StatisticsReports;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StatisticsReportsArchivesController : ControllerBase
{
    private readonly IMediator _mediator;

    public StatisticsReportsArchivesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StatisticsReportsArchiveDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStatisticsReportsArchivesQuery());
        return Ok(ApiResponse<IEnumerable<StatisticsReportsArchiveDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StatisticsReportsArchiveDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStatisticsReportsArchiveByIdQuery { Id = id });
        return Ok(ApiResponse<StatisticsReportsArchiveDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStatisticsReportsArchiveDto dto)
    {
        var id = await _mediator.Send(new CreateStatisticsReportsArchiveCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }
}