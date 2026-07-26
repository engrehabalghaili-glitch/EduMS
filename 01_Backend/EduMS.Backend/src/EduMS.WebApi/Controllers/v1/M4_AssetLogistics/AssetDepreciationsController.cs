using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetDepreciations;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetDepreciations;
using EduMS.Application.M4_AssetLogistics.Queries.AssetDepreciations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetDepreciationsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetDepreciationDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetDepreciationsQuery());
        return Ok(ApiResponse<IEnumerable<AssetDepreciationDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetDepreciationDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetDepreciationByIdQuery { Id = id });
        return Ok(ApiResponse<AssetDepreciationDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetDepreciationDto dto)
    {
        var id = await sender.Send(new CreateAssetDepreciationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetDepreciationDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetDepreciationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetDepreciationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



