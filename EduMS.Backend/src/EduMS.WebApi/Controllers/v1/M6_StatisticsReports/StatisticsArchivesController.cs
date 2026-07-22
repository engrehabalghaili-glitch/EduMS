using EduMS.Application.Common.Responses;
using EduMS.Application.M6_StatisticsReports.Commands.StatisticsArchives;
using EduMS.Application.M6_StatisticsReports.DTOs.StatisticsArchives;
using EduMS.Application.M6_StatisticsReports.Queries.StatisticsArchives;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M6_StatisticsReports;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StatisticsArchivesController : ControllerBase
{
    private readonly IMediator _mediator;

    public StatisticsArchivesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StatisticsArchiveDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStatisticsArchivesQuery());
        return Ok(ApiResponse<IEnumerable<StatisticsArchiveDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StatisticsArchiveDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStatisticsArchiveByIdQuery { Id = id });
        return Ok(ApiResponse<StatisticsArchiveDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStatisticsArchiveDto dto)
    {
        var id = await _mediator.Send(new CreateStatisticsArchiveCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }
}