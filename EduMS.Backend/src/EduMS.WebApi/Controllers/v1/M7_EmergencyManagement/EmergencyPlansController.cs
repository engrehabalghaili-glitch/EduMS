using EduMS.Application.Common.Responses;
using EduMS.Application.M7_EmergencyManagement.Commands.EmergencyPlans;
using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyPlans;
using EduMS.Application.M7_EmergencyManagement.Queries.EmergencyPlans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M7_EmergencyManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmergencyPlansController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmergencyPlansController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmergencyPlanDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllEmergencyPlansQuery());
        return Ok(ApiResponse<IEnumerable<EmergencyPlanDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmergencyPlanDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetEmergencyPlanByIdQuery { Id = id });
        return Ok(ApiResponse<EmergencyPlanDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmergencyPlanDto dto)
    {
        var id = await _mediator.Send(new CreateEmergencyPlanCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmergencyPlanDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateEmergencyPlanCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteEmergencyPlanCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}