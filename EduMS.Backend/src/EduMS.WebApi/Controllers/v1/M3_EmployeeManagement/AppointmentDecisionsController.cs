using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.AppointmentDecisions;
using EduMS.Application.M3_EmployeeManagement.DTOs.AppointmentDecisions;
using EduMS.Application.M3_EmployeeManagement.Queries.AppointmentDecisions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AppointmentDecisionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentDecisionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AppointmentDecisionDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAppointmentDecisionsQuery());
        return Ok(ApiResponse<IEnumerable<AppointmentDecisionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AppointmentDecisionDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAppointmentDecisionByIdQuery { Id = id });
        return Ok(ApiResponse<AppointmentDecisionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAppointmentDecisionDto dto)
    {
        var id = await _mediator.Send(new CreateAppointmentDecisionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAppointmentDecisionDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAppointmentDecisionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAppointmentDecisionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}