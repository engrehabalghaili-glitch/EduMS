using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.RoleMatrixes;
using EduMS.Application.M8_AuthenticationUsers.DTOs.RoleMatrixes;
using EduMS.Application.M8_AuthenticationUsers.Queries.RoleMatrixes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class RoleMatrixesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.RoleMatrixes.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<RoleMatrixDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllRoleMatrixesQuery());
        return Ok(ApiResponse<IEnumerable<RoleMatrixDto>>.Success(result));
    }

    [HasPermission(Permissions.RoleMatrixes.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<RoleMatrixDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetRoleMatrixByIdQuery { Id = id });
        return Ok(ApiResponse<RoleMatrixDto>.Success(result));
    }

    [HasPermission(Permissions.RoleMatrixes.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateRoleMatrixDto dto)
    {
        var id = await sender.Send(new CreateRoleMatrixCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.RoleMatrixes.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateRoleMatrixDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateRoleMatrixCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.RoleMatrixes.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteRoleMatrixCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




