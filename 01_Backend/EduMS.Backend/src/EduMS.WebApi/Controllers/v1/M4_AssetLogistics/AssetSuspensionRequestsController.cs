using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetSuspensionRequests;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetSuspensionRequests;
using EduMS.Application.M4_AssetLogistics.Queries.AssetSuspensionRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetSuspensionRequestsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetSuspensionRequests.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetSuspensionRequestDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetSuspensionRequestsQuery());
        return Ok(ApiResponse<IEnumerable<AssetSuspensionRequestDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetSuspensionRequests.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetSuspensionRequestDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetSuspensionRequestByIdQuery { Id = id });
        return Ok(ApiResponse<AssetSuspensionRequestDto>.Success(result));
    }

    [HasPermission(Permissions.AssetSuspensionRequests.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetSuspensionRequestDto dto)
    {
        var id = await sender.Send(new CreateAssetSuspensionRequestCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetSuspensionRequests.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetSuspensionRequestDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetSuspensionRequestCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetSuspensionRequests.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetSuspensionRequestCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




