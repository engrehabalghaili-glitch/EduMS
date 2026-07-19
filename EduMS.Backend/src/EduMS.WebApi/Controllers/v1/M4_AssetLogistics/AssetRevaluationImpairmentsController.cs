using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetRevaluationImpairments;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetRevaluationImpairments;
using EduMS.Application.M4_AssetLogistics.Queries.AssetRevaluationImpairments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetRevaluationImpairmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetRevaluationImpairmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetRevaluationImpairmentDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAssetRevaluationImpairmentsQuery());
        return Ok(ApiResponse<IEnumerable<AssetRevaluationImpairmentDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetRevaluationImpairmentDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAssetRevaluationImpairmentByIdQuery { Id = id });
        return Ok(ApiResponse<AssetRevaluationImpairmentDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetRevaluationImpairmentDto dto)
    {
        var id = await _mediator.Send(new CreateAssetRevaluationImpairmentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetRevaluationImpairmentDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAssetRevaluationImpairmentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAssetRevaluationImpairmentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}