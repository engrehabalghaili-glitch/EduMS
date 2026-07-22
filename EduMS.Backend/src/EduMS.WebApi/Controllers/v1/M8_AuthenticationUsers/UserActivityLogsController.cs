using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.UserActivityLogs;
using EduMS.Application.M8_AuthenticationUsers.DTOs.UserActivityLogs;
using EduMS.Application.M8_AuthenticationUsers.Queries.UserActivityLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class UserActivityLogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserActivityLogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<UserActivityLogDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllUserActivityLogsQuery());
        return Ok(ApiResponse<IEnumerable<UserActivityLogDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<UserActivityLogDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetUserActivityLogByIdQuery { Id = id });
        return Ok(ApiResponse<UserActivityLogDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateUserActivityLogDto dto)
    {
        var id = await _mediator.Send(new CreateUserActivityLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateUserActivityLogDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateUserActivityLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteUserActivityLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}