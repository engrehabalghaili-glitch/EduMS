using EduMS.Application.Common.Responses;
using EduMS.Application.M7_EmergencyManagement.Commands.EmergencyIncidents;
using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyIncidents;
using EduMS.Application.M7_EmergencyManagement.Queries.EmergencyIncidents;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M7_EmergencyManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmergencyIncidentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmergencyIncidentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmergencyIncidentDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllEmergencyIncidentsQuery());
        return Ok(ApiResponse<IEnumerable<EmergencyIncidentDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmergencyIncidentDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetEmergencyIncidentByIdQuery { Id = id });
        return Ok(ApiResponse<EmergencyIncidentDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmergencyIncidentDto dto)
    {
        var id = await _mediator.Send(new CreateEmergencyIncidentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmergencyIncidentDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateEmergencyIncidentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteEmergencyIncidentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}