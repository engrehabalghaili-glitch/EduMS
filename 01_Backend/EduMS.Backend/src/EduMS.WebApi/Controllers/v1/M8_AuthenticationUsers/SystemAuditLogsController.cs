using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.SystemAuditLogs;
using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemAuditLogs;
using EduMS.Application.M8_AuthenticationUsers.Queries.SystemAuditLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SystemAuditLogsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SystemAuditLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSystemAuditLogsQuery());
        return Ok(ApiResponse<IEnumerable<SystemAuditLogDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SystemAuditLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSystemAuditLogByIdQuery { Id = id });
        return Ok(ApiResponse<SystemAuditLogDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSystemAuditLogDto dto)
    {
        var id = await sender.Send(new CreateSystemAuditLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSystemAuditLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSystemAuditLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSystemAuditLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



