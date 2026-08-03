using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetLoanTrackingAlerts;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetLoanTrackingAlerts;
using EduMS.Application.M4_AssetLogistics.Queries.AssetLoanTrackingAlerts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetLoanTrackingAlertsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetLoanTrackingAlerts.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetLoanTrackingAlertDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetLoanTrackingAlertsQuery());
        return Ok(ApiResponse<IEnumerable<AssetLoanTrackingAlertDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetLoanTrackingAlerts.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetLoanTrackingAlertDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetLoanTrackingAlertByIdQuery { Id = id });
        return Ok(ApiResponse<AssetLoanTrackingAlertDto>.Success(result));
    }

    [HasPermission(Permissions.AssetLoanTrackingAlerts.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetLoanTrackingAlertDto dto)
    {
        var id = await sender.Send(new CreateAssetLoanTrackingAlertCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetLoanTrackingAlerts.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetLoanTrackingAlertDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetLoanTrackingAlertCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetLoanTrackingAlerts.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetLoanTrackingAlertCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




