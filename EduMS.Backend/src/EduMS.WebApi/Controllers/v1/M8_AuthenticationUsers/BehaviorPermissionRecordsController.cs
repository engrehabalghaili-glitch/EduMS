using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.BehaviorPermissionRecords;
using EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissionRecords;
using EduMS.Application.M8_AuthenticationUsers.Queries.BehaviorPermissionRecords;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class BehaviorPermissionRecordsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BehaviorPermissionRecordsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<BehaviorPermissionRecordDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllBehaviorPermissionRecordsQuery());
        return Ok(ApiResponse<IEnumerable<BehaviorPermissionRecordDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<BehaviorPermissionRecordDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetBehaviorPermissionRecordByIdQuery { Id = id });
        return Ok(ApiResponse<BehaviorPermissionRecordDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateBehaviorPermissionRecordDto dto)
    {
        var id = await _mediator.Send(new CreateBehaviorPermissionRecordCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateBehaviorPermissionRecordDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateBehaviorPermissionRecordCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteBehaviorPermissionRecordCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}