using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.RolePermissions;
using EduMS.Application.M8_AuthenticationUsers.DTOs.RolePermissions;
using EduMS.Application.M8_AuthenticationUsers.Queries.RolePermissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class RolePermissionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolePermissionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<RolePermissionDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllRolePermissionsQuery());
        return Ok(ApiResponse<IEnumerable<RolePermissionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<RolePermissionDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetRolePermissionByIdQuery { Id = id });
        return Ok(ApiResponse<RolePermissionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateRolePermissionDto dto)
    {
        var id = await _mediator.Send(new CreateRolePermissionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateRolePermissionDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateRolePermissionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteRolePermissionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}