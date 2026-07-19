using EduMS.Application.Common.Responses;
using EduMS.Application.M6_StatisticsReports.Commands.StatisticsUpdateHistories;
using EduMS.Application.M6_StatisticsReports.DTOs.StatisticsUpdateHistories;
using EduMS.Application.M6_StatisticsReports.Queries.StatisticsUpdateHistories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M6_StatisticsReports;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StatisticsUpdateHistoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public StatisticsUpdateHistoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StatisticsUpdateHistoryDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStatisticsUpdateHistoriesQuery());
        return Ok(ApiResponse<IEnumerable<StatisticsUpdateHistoryDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StatisticsUpdateHistoryDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStatisticsUpdateHistoryByIdQuery { Id = id });
        return Ok(ApiResponse<StatisticsUpdateHistoryDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStatisticsUpdateHistoryDto dto)
    {
        var id = await _mediator.Send(new CreateStatisticsUpdateHistoryCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }
}