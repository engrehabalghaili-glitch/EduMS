using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetMaintenanceTickets;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetMaintenanceTickets;
using EduMS.Application.M4_AssetLogistics.Queries.AssetMaintenanceTickets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetMaintenanceTicketsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetMaintenanceTickets.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetMaintenanceTicketDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetMaintenanceTicketsQuery());
        return Ok(ApiResponse<IEnumerable<AssetMaintenanceTicketDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetMaintenanceTickets.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetMaintenanceTicketDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetMaintenanceTicketByIdQuery { Id = id });
        return Ok(ApiResponse<AssetMaintenanceTicketDto>.Success(result));
    }

    [HasPermission(Permissions.AssetMaintenanceTickets.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetMaintenanceTicketDto dto)
    {
        var id = await sender.Send(new CreateAssetMaintenanceTicketCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetMaintenanceTickets.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetMaintenanceTicketDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetMaintenanceTicketCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetMaintenanceTickets.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetMaintenanceTicketCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




