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
public class AssetSuspensionRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetSuspensionRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetSuspensionRequestDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAssetSuspensionRequestsQuery());
        return Ok(ApiResponse<IEnumerable<AssetSuspensionRequestDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetSuspensionRequestDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAssetSuspensionRequestByIdQuery { Id = id });
        return Ok(ApiResponse<AssetSuspensionRequestDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetSuspensionRequestDto dto)
    {
        var id = await _mediator.Send(new CreateAssetSuspensionRequestCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetSuspensionRequestDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAssetSuspensionRequestCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAssetSuspensionRequestCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}