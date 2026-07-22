using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.MaintenanceExecutions;
using EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceExecutions;
using EduMS.Application.M4_AssetLogistics.Queries.MaintenanceExecutions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class MaintenanceExecutionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MaintenanceExecutionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<MaintenanceExecutionDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllMaintenanceExecutionsQuery());
        return Ok(ApiResponse<IEnumerable<MaintenanceExecutionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<MaintenanceExecutionDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetMaintenanceExecutionByIdQuery { Id = id });
        return Ok(ApiResponse<MaintenanceExecutionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateMaintenanceExecutionDto dto)
    {
        var id = await _mediator.Send(new CreateMaintenanceExecutionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateMaintenanceExecutionDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateMaintenanceExecutionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteMaintenanceExecutionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}