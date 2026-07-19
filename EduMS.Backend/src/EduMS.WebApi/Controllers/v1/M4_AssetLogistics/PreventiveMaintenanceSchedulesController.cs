using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.PreventiveMaintenanceSchedules;
using EduMS.Application.M4_AssetLogistics.DTOs.PreventiveMaintenanceSchedules;
using EduMS.Application.M4_AssetLogistics.Queries.PreventiveMaintenanceSchedules;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class PreventiveMaintenanceSchedulesController : ControllerBase
{
    private readonly IMediator _mediator;

    public PreventiveMaintenanceSchedulesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<PreventiveMaintenanceScheduleDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllPreventiveMaintenanceSchedulesQuery());
        return Ok(ApiResponse<IEnumerable<PreventiveMaintenanceScheduleDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<PreventiveMaintenanceScheduleDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetPreventiveMaintenanceScheduleByIdQuery { Id = id });
        return Ok(ApiResponse<PreventiveMaintenanceScheduleDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreatePreventiveMaintenanceScheduleDto dto)
    {
        var id = await _mediator.Send(new CreatePreventiveMaintenanceScheduleCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdatePreventiveMaintenanceScheduleDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdatePreventiveMaintenanceScheduleCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeletePreventiveMaintenanceScheduleCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}