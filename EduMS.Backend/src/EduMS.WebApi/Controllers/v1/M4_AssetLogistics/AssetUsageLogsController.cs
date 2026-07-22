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
public class AssetUsageLogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetUsageLogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetUsageLogDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAssetUsageLogsQuery());
        return Ok(ApiResponse<IEnumerable<AssetUsageLogDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetUsageLogDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAssetUsageLogByIdQuery { Id = id });
        return Ok(ApiResponse<AssetUsageLogDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetUsageLogDto dto)
    {
        var id = await _mediator.Send(new CreateAssetUsageLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetUsageLogDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAssetUsageLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAssetUsageLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}