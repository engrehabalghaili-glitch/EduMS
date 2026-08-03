using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.SystemUsers;
using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemUsers;
using EduMS.Application.M8_AuthenticationUsers.Queries.SystemUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Domain.Constants;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SystemUsersController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    [HasPermission(Permissions.SystemUsers.View)]
    public async Task<ActionResult<ApiResponse<IEnumerable<SystemUserDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSystemUsersQuery());
        return Ok(ApiResponse<IEnumerable<SystemUserDto>>.Success(result));
    }

    [HttpGet("{id}")]
    [HasPermission(Permissions.SystemUsers.View)]
    public async Task<ActionResult<ApiResponse<SystemUserDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSystemUserByIdQuery { Id = id });
        return Ok(ApiResponse<SystemUserDto>.Success(result));
    }

    [HttpPost]
    [HasPermission(Permissions.SystemUsers.Create)]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSystemUserDto dto)
    {
        var id = await sender.Send(new CreateSystemUserCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    [HasPermission(Permissions.SystemUsers.Update)]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSystemUserDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSystemUserCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    [HasPermission(Permissions.SystemUsers.Delete)]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSystemUserCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



