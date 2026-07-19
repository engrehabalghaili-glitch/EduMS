using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.StudentAcademicPermissions;
using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentAcademicPermissions;
using EduMS.Application.M8_AuthenticationUsers.Queries.StudentAcademicPermissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentAcademicPermissionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentAcademicPermissionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentAcademicPermissionDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentAcademicPermissionsQuery());
        return Ok(ApiResponse<IEnumerable<StudentAcademicPermissionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentAcademicPermissionDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentAcademicPermissionByIdQuery { Id = id });
        return Ok(ApiResponse<StudentAcademicPermissionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentAcademicPermissionDto dto)
    {
        var id = await _mediator.Send(new CreateStudentAcademicPermissionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentAcademicPermissionDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentAcademicPermissionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentAcademicPermissionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}