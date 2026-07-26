using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.PermissionTypes;
using EduMS.Application.M8_AuthenticationUsers.DTOs.PermissionTypes;
using EduMS.Application.M8_AuthenticationUsers.Queries.PermissionTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class PermissionTypesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<PermissionTypeDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllPermissionTypesQuery());
        return Ok(ApiResponse<IEnumerable<PermissionTypeDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<PermissionTypeDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetPermissionTypeByIdQuery { Id = id });
        return Ok(ApiResponse<PermissionTypeDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreatePermissionTypeDto dto)
    {
        var id = await sender.Send(new CreatePermissionTypeCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdatePermissionTypeDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdatePermissionTypeCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeletePermissionTypeCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



