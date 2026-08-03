using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetUsageLogs;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetUsageLogs;
using EduMS.Application.M4_AssetLogistics.Queries.AssetUsageLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetUsageLogsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetUsageLogs.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetUsageLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetUsageLogsQuery());
        return Ok(ApiResponse<IEnumerable<AssetUsageLogDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetUsageLogs.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetUsageLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetUsageLogByIdQuery { Id = id });
        return Ok(ApiResponse<AssetUsageLogDto>.Success(result));
    }

    [HasPermission(Permissions.AssetUsageLogs.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetUsageLogDto dto)
    {
        var id = await sender.Send(new CreateAssetUsageLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetUsageLogs.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetUsageLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetUsageLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetUsageLogs.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetUsageLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




