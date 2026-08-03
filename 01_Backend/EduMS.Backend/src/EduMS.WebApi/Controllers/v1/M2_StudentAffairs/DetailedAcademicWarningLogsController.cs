using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.DetailedAcademicWarningLogs;
using EduMS.Application.M2_StudentAffairs.DTOs.DetailedAcademicWarningLogs;
using EduMS.Application.M2_StudentAffairs.Queries.DetailedAcademicWarningLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class DetailedAcademicWarningLogsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.DetailedAcademicWarningLogs.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<DetailedAcademicWarningLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllDetailedAcademicWarningLogsQuery());
        return Ok(ApiResponse<IEnumerable<DetailedAcademicWarningLogDto>>.Success(result));
    }

    [HasPermission(Permissions.DetailedAcademicWarningLogs.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<DetailedAcademicWarningLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetDetailedAcademicWarningLogByIdQuery { Id = id });
        return Ok(ApiResponse<DetailedAcademicWarningLogDto>.Success(result));
    }

    [HasPermission(Permissions.DetailedAcademicWarningLogs.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateDetailedAcademicWarningLogDto dto)
    {
        var id = await sender.Send(new CreateDetailedAcademicWarningLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.DetailedAcademicWarningLogs.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateDetailedAcademicWarningLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateDetailedAcademicWarningLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.DetailedAcademicWarningLogs.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteDetailedAcademicWarningLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




