using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M6_StatisticsReports.Commands.SubmittedStatisticses;
using EduMS.Application.M6_StatisticsReports.DTOs.SubmittedStatisticses;
using EduMS.Application.M6_StatisticsReports.Queries.SubmittedStatisticses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M6_StatisticsReports;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SubmittedStatisticsesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.SubmittedStatisticses.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SubmittedStatisticsDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSubmittedStatisticsesQuery());
        return Ok(ApiResponse<IEnumerable<SubmittedStatisticsDto>>.Success(result));
    }

    [HasPermission(Permissions.SubmittedStatisticses.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SubmittedStatisticsDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSubmittedStatisticsByIdQuery { Id = id });
        return Ok(ApiResponse<SubmittedStatisticsDto>.Success(result));
    }

    [HasPermission(Permissions.SubmittedStatisticses.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSubmittedStatisticsDto dto)
    {
        var id = await sender.Send(new CreateSubmittedStatisticsCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }
}




