using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetReceivings;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetReceivings;
using EduMS.Application.M4_AssetLogistics.Queries.AssetReceivings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetReceivingsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetReceivings.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetReceivingDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetReceivingsQuery());
        return Ok(ApiResponse<IEnumerable<AssetReceivingDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetReceivings.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetReceivingDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetReceivingByIdQuery { Id = id });
        return Ok(ApiResponse<AssetReceivingDto>.Success(result));
    }

    [HasPermission(Permissions.AssetReceivings.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetReceivingDto dto)
    {
        var id = await sender.Send(new CreateAssetReceivingCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetReceivings.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetReceivingDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetReceivingCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetReceivings.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetReceivingCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




