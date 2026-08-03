using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
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
public class StudentBasePermissionsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentBasePermissions.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentBasePermissionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentBasePermissionsQuery());
        return Ok(ApiResponse<IEnumerable<StudentBasePermissionDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentBasePermissions.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentBasePermissionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentBasePermissionByIdQuery { Id = id });
        return Ok(ApiResponse<StudentBasePermissionDto>.Success(result));
    }

    [HasPermission(Permissions.StudentBasePermissions.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentBasePermissionDto dto)
    {
        var id = await sender.Send(new CreateStudentBasePermissionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentBasePermissions.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentBasePermissionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentBasePermissionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentBasePermissions.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentBasePermissionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




