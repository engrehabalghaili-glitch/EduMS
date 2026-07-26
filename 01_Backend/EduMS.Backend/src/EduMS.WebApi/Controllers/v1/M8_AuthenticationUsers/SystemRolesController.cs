using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.SystemRoles;
using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemRoles;
using EduMS.Application.M8_AuthenticationUsers.Queries.SystemRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SystemRolesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SystemRoleDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSystemRolesQuery());
        return Ok(ApiResponse<IEnumerable<SystemRoleDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SystemRoleDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSystemRoleByIdQuery { Id = id });
        return Ok(ApiResponse<SystemRoleDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSystemRoleDto dto)
    {
        var id = await sender.Send(new CreateSystemRoleCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSystemRoleDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSystemRoleCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSystemRoleCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



