using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolAnnouncementLogs;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAnnouncementLogs;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolAnnouncementLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolAnnouncementLogsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.SchoolAnnouncementLogs.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolAnnouncementLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSchoolAnnouncementLogsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolAnnouncementLogDto>>.Success(result));
    }

        [HasPermission(Permissions.SchoolAnnouncementLogs.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolAnnouncementLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSchoolAnnouncementLogByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolAnnouncementLogDto>.Success(result));
    }

    [HasPermission(Permissions.SchoolAnnouncementLogs.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolAnnouncementLogDto dto)
    {
        var id = await sender.Send(new CreateSchoolAnnouncementLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.SchoolAnnouncementLogs.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolAnnouncementLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSchoolAnnouncementLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.SchoolAnnouncementLogs.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSchoolAnnouncementLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







