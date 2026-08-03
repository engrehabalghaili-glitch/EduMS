using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolAuditLogs;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAuditLogs;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolAuditLogs;
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
public class SchoolAuditLogsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.SchoolAuditLogs.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolAuditLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSchoolAuditLogsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolAuditLogDto>>.Success(result));
    }

        [HasPermission(Permissions.SchoolAuditLogs.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolAuditLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSchoolAuditLogByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolAuditLogDto>.Success(result));
    }

    [HasPermission(Permissions.SchoolAuditLogs.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolAuditLogDto dto)
    {
        var id = await sender.Send(new CreateSchoolAuditLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.SchoolAuditLogs.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolAuditLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSchoolAuditLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.SchoolAuditLogs.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSchoolAuditLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







