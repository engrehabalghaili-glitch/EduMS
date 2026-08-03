using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
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
public class StatisticsUpdateHistoriesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StatisticsUpdateHistories.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StatisticsUpdateHistoryDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStatisticsUpdateHistoriesQuery());
        return Ok(ApiResponse<IEnumerable<StatisticsUpdateHistoryDto>>.Success(result));
    }

    [HasPermission(Permissions.StatisticsUpdateHistories.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StatisticsUpdateHistoryDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStatisticsUpdateHistoryByIdQuery { Id = id });
        return Ok(ApiResponse<StatisticsUpdateHistoryDto>.Success(result));
    }

    [HasPermission(Permissions.StatisticsUpdateHistories.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStatisticsUpdateHistoryDto dto)
    {
        var id = await sender.Send(new CreateStatisticsUpdateHistoryCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }
}




