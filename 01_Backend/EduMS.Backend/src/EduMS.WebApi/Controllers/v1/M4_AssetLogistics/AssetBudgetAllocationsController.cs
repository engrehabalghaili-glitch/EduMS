using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetBudgetAllocations;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetBudgetAllocations;
using EduMS.Application.M4_AssetLogistics.Queries.AssetBudgetAllocations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetBudgetAllocationsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetBudgetAllocations.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetBudgetAllocationDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetBudgetAllocationsQuery());
        return Ok(ApiResponse<IEnumerable<AssetBudgetAllocationDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetBudgetAllocations.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetBudgetAllocationDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetBudgetAllocationByIdQuery { Id = id });
        return Ok(ApiResponse<AssetBudgetAllocationDto>.Success(result));
    }

    [HasPermission(Permissions.AssetBudgetAllocations.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetBudgetAllocationDto dto)
    {
        var id = await sender.Send(new CreateAssetBudgetAllocationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetBudgetAllocations.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetBudgetAllocationDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetBudgetAllocationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetBudgetAllocations.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetBudgetAllocationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




