using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetInspectionLogs;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetInspectionLogs;
using EduMS.Application.M4_AssetLogistics.Queries.AssetInspectionLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetInspectionLogsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetInspectionLogs.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetInspectionLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetInspectionLogsQuery());
        return Ok(ApiResponse<IEnumerable<AssetInspectionLogDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetInspectionLogs.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetInspectionLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetInspectionLogByIdQuery { Id = id });
        return Ok(ApiResponse<AssetInspectionLogDto>.Success(result));
    }

    [HasPermission(Permissions.AssetInspectionLogs.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetInspectionLogDto dto)
    {
        var id = await sender.Send(new CreateAssetInspectionLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetInspectionLogs.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetInspectionLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetInspectionLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetInspectionLogs.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetInspectionLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




