using EduMS.Application.Common.Responses;
using EduMS.Application.M7_EmergencyManagement.Commands.EmergencyHostings;
using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyHostings;
using EduMS.Application.M7_EmergencyManagement.Queries.EmergencyHostings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M7_EmergencyManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmergencyHostingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmergencyHostingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmergencyHostingDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllEmergencyHostingsQuery());
        return Ok(ApiResponse<IEnumerable<EmergencyHostingDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmergencyHostingDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetEmergencyHostingByIdQuery { Id = id });
        return Ok(ApiResponse<EmergencyHostingDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmergencyHostingDto dto)
    {
        var id = await _mediator.Send(new CreateEmergencyHostingCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmergencyHostingDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateEmergencyHostingCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteEmergencyHostingCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}