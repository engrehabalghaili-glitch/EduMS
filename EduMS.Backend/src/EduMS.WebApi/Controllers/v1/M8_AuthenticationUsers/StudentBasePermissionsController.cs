using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.StudentBasePermissions;
using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentBasePermissions;
using EduMS.Application.M8_AuthenticationUsers.Queries.StudentBasePermissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentBasePermissionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentBasePermissionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentBasePermissionDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentBasePermissionsQuery());
        return Ok(ApiResponse<IEnumerable<StudentBasePermissionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentBasePermissionDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentBasePermissionByIdQuery { Id = id });
        return Ok(ApiResponse<StudentBasePermissionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentBasePermissionDto dto)
    {
        var id = await _mediator.Send(new CreateStudentBasePermissionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentBasePermissionDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentBasePermissionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentBasePermissionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}