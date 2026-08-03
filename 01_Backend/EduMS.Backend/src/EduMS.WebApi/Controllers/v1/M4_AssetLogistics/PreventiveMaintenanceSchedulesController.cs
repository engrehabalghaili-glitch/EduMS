using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
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
public class PreventiveMaintenanceSchedulesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.PreventiveMaintenanceSchedules.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<PreventiveMaintenanceScheduleDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllPreventiveMaintenanceSchedulesQuery());
        return Ok(ApiResponse<IEnumerable<PreventiveMaintenanceScheduleDto>>.Success(result));
    }

    [HasPermission(Permissions.PreventiveMaintenanceSchedules.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<PreventiveMaintenanceScheduleDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetPreventiveMaintenanceScheduleByIdQuery { Id = id });
        return Ok(ApiResponse<PreventiveMaintenanceScheduleDto>.Success(result));
    }

    [HasPermission(Permissions.PreventiveMaintenanceSchedules.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreatePreventiveMaintenanceScheduleDto dto)
    {
        var id = await sender.Send(new CreatePreventiveMaintenanceScheduleCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.PreventiveMaintenanceSchedules.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdatePreventiveMaintenanceScheduleDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdatePreventiveMaintenanceScheduleCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.PreventiveMaintenanceSchedules.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeletePreventiveMaintenanceScheduleCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




