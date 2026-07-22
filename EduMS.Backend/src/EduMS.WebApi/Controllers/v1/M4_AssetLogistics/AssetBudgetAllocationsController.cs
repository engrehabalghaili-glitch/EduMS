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
public class AssetBudgetAllocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetBudgetAllocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetBudgetAllocationDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAssetBudgetAllocationsQuery());
        return Ok(ApiResponse<IEnumerable<AssetBudgetAllocationDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetBudgetAllocationDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAssetBudgetAllocationByIdQuery { Id = id });
        return Ok(ApiResponse<AssetBudgetAllocationDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetBudgetAllocationDto dto)
    {
        var id = await _mediator.Send(new CreateAssetBudgetAllocationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetBudgetAllocationDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAssetBudgetAllocationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAssetBudgetAllocationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}