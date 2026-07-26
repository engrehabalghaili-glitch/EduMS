using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetAllocations;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetAllocations;
using EduMS.Application.M4_AssetLogistics.Queries.AssetAllocations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetAllocationsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetAllocationDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetAllocationsQuery());
        return Ok(ApiResponse<IEnumerable<AssetAllocationDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetAllocationDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetAllocationByIdQuery { Id = id });
        return Ok(ApiResponse<AssetAllocationDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetAllocationDto dto)
    {
        var id = await sender.Send(new CreateAssetAllocationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetAllocationDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetAllocationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetAllocationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



