using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.StudentPermissionAuditLogs;
using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentPermissionAuditLogs;
using EduMS.Application.M8_AuthenticationUsers.Queries.StudentPermissionAuditLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentPermissionAuditLogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentPermissionAuditLogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentPermissionAuditLogDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentPermissionAuditLogsQuery());
        return Ok(ApiResponse<IEnumerable<StudentPermissionAuditLogDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentPermissionAuditLogDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentPermissionAuditLogByIdQuery { Id = id });
        return Ok(ApiResponse<StudentPermissionAuditLogDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentPermissionAuditLogDto dto)
    {
        var id = await _mediator.Send(new CreateStudentPermissionAuditLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentPermissionAuditLogDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentPermissionAuditLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentPermissionAuditLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}