using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.OfficePermissions;
using EduMS.Application.M8_AuthenticationUsers.DTOs.OfficePermissions;
using EduMS.Application.M8_AuthenticationUsers.Queries.OfficePermissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class OfficePermissionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OfficePermissionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<OfficePermissionDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllOfficePermissionsQuery());
        return Ok(ApiResponse<IEnumerable<OfficePermissionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<OfficePermissionDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetOfficePermissionByIdQuery { Id = id });
        return Ok(ApiResponse<OfficePermissionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateOfficePermissionDto dto)
    {
        var id = await _mediator.Send(new CreateOfficePermissionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateOfficePermissionDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateOfficePermissionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteOfficePermissionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}