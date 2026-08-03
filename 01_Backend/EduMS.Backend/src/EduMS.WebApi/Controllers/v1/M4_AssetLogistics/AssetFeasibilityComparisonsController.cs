using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetFeasibilityComparisons;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetFeasibilityComparisons;
using EduMS.Application.M4_AssetLogistics.Queries.AssetFeasibilityComparisons;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetFeasibilityComparisonsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetFeasibilityComparisons.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetFeasibilityComparisonDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetFeasibilityComparisonsQuery());
        return Ok(ApiResponse<IEnumerable<AssetFeasibilityComparisonDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetFeasibilityComparisons.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetFeasibilityComparisonDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetFeasibilityComparisonByIdQuery { Id = id });
        return Ok(ApiResponse<AssetFeasibilityComparisonDto>.Success(result));
    }

    [HasPermission(Permissions.AssetFeasibilityComparisons.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetFeasibilityComparisonDto dto)
    {
        var id = await sender.Send(new CreateAssetFeasibilityComparisonCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetFeasibilityComparisons.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetFeasibilityComparisonDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetFeasibilityComparisonCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetFeasibilityComparisons.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetFeasibilityComparisonCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




