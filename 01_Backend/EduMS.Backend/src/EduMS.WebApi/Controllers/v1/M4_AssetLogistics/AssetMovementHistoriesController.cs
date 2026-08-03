using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetMovementHistories;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetMovementHistories;
using EduMS.Application.M4_AssetLogistics.Queries.AssetMovementHistories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetMovementHistoriesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetMovementHistories.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetMovementHistoryDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetMovementHistoriesQuery());
        return Ok(ApiResponse<IEnumerable<AssetMovementHistoryDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetMovementHistories.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetMovementHistoryDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetMovementHistoryByIdQuery { Id = id });
        return Ok(ApiResponse<AssetMovementHistoryDto>.Success(result));
    }

    [HasPermission(Permissions.AssetMovementHistories.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetMovementHistoryDto dto)
    {
        var id = await sender.Send(new CreateAssetMovementHistoryCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetMovementHistories.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetMovementHistoryDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetMovementHistoryCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetMovementHistories.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetMovementHistoryCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




