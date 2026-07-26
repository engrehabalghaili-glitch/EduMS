using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.StudentFinancePermissions;
using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentFinancePermissions;
using EduMS.Application.M8_AuthenticationUsers.Queries.StudentFinancePermissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentFinancePermissionsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentFinancePermissionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentFinancePermissionsQuery());
        return Ok(ApiResponse<IEnumerable<StudentFinancePermissionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentFinancePermissionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentFinancePermissionByIdQuery { Id = id });
        return Ok(ApiResponse<StudentFinancePermissionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentFinancePermissionDto dto)
    {
        var id = await sender.Send(new CreateStudentFinancePermissionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentFinancePermissionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentFinancePermissionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentFinancePermissionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



