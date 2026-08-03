using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
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
public class StatisticsArchivesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StatisticsArchives.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StatisticsArchiveDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStatisticsArchivesQuery());
        return Ok(ApiResponse<IEnumerable<StatisticsArchiveDto>>.Success(result));
    }

    [HasPermission(Permissions.StatisticsArchives.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StatisticsArchiveDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStatisticsArchiveByIdQuery { Id = id });
        return Ok(ApiResponse<StatisticsArchiveDto>.Success(result));
    }

    [HasPermission(Permissions.StatisticsArchives.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStatisticsArchiveDto dto)
    {
        var id = await sender.Send(new CreateStatisticsArchiveCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }
}




