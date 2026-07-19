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
public class AssetMovementHistoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetMovementHistoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetMovementHistoryDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAssetMovementHistoriesQuery());
        return Ok(ApiResponse<IEnumerable<AssetMovementHistoryDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetMovementHistoryDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAssetMovementHistoryByIdQuery { Id = id });
        return Ok(ApiResponse<AssetMovementHistoryDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetMovementHistoryDto dto)
    {
        var id = await _mediator.Send(new CreateAssetMovementHistoryCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetMovementHistoryDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAssetMovementHistoryCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAssetMovementHistoryCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}