using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M6_StatisticsReports.Commands.StatisticalReportSnapshots;
using EduMS.Application.M6_StatisticsReports.DTOs.StatisticalReportSnapshots;
using EduMS.Application.M6_StatisticsReports.Queries.StatisticalReportSnapshots;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M6_StatisticsReports;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StatisticalReportSnapshotsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StatisticalReportSnapshots.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StatisticalReportSnapshotDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStatisticalReportSnapshotsQuery());
        return Ok(ApiResponse<IEnumerable<StatisticalReportSnapshotDto>>.Success(result));
    }

    [HasPermission(Permissions.StatisticalReportSnapshots.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StatisticalReportSnapshotDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStatisticalReportSnapshotByIdQuery { Id = id });
        return Ok(ApiResponse<StatisticalReportSnapshotDto>.Success(result));
    }

    [HasPermission(Permissions.StatisticalReportSnapshots.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStatisticalReportSnapshotDto dto)
    {
        var id = await sender.Send(new CreateStatisticalReportSnapshotCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }
}




