using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
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
public class MaintenanceExecutionsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.MaintenanceExecutions.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<MaintenanceExecutionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllMaintenanceExecutionsQuery());
        return Ok(ApiResponse<IEnumerable<MaintenanceExecutionDto>>.Success(result));
    }

    [HasPermission(Permissions.MaintenanceExecutions.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<MaintenanceExecutionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetMaintenanceExecutionByIdQuery { Id = id });
        return Ok(ApiResponse<MaintenanceExecutionDto>.Success(result));
    }

    [HasPermission(Permissions.MaintenanceExecutions.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateMaintenanceExecutionDto dto)
    {
        var id = await sender.Send(new CreateMaintenanceExecutionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.MaintenanceExecutions.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateMaintenanceExecutionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateMaintenanceExecutionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.MaintenanceExecutions.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteMaintenanceExecutionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




