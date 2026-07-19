using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.SystemUsers;
using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemUsers;
using EduMS.Application.M8_AuthenticationUsers.Queries.SystemUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SystemUsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public SystemUsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SystemUserDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSystemUsersQuery());
        return Ok(ApiResponse<IEnumerable<SystemUserDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SystemUserDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSystemUserByIdQuery { Id = id });
        return Ok(ApiResponse<SystemUserDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSystemUserDto dto)
    {
        var id = await _mediator.Send(new CreateSystemUserCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSystemUserDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateSystemUserCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteSystemUserCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}