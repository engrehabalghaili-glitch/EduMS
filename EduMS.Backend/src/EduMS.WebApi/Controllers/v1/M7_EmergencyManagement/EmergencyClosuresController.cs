using EduMS.Application.Common.Responses;
using EduMS.Application.M7_EmergencyManagement.Commands.EmergencyClosures;
using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyClosures;
using EduMS.Application.M7_EmergencyManagement.Queries.EmergencyClosures;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M7_EmergencyManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmergencyClosuresController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmergencyClosuresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmergencyClosureDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllEmergencyClosuresQuery());
        return Ok(ApiResponse<IEnumerable<EmergencyClosureDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmergencyClosureDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetEmergencyClosureByIdQuery { Id = id });
        return Ok(ApiResponse<EmergencyClosureDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmergencyClosureDto dto)
    {
        var id = await _mediator.Send(new CreateEmergencyClosureCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmergencyClosureDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateEmergencyClosureCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteEmergencyClosureCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}