using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.MaintenanceNotifications;
using EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceNotifications;
using EduMS.Application.M4_AssetLogistics.Queries.MaintenanceNotifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class MaintenanceNotificationsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.MaintenanceNotifications.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<MaintenanceNotificationDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllMaintenanceNotificationsQuery());
        return Ok(ApiResponse<IEnumerable<MaintenanceNotificationDto>>.Success(result));
    }

    [HasPermission(Permissions.MaintenanceNotifications.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<MaintenanceNotificationDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetMaintenanceNotificationByIdQuery { Id = id });
        return Ok(ApiResponse<MaintenanceNotificationDto>.Success(result));
    }

    [HasPermission(Permissions.MaintenanceNotifications.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateMaintenanceNotificationDto dto)
    {
        var id = await sender.Send(new CreateMaintenanceNotificationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.MaintenanceNotifications.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateMaintenanceNotificationDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateMaintenanceNotificationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.MaintenanceNotifications.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteMaintenanceNotificationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




