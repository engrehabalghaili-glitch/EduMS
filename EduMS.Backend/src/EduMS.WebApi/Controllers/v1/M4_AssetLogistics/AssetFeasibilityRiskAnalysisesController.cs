using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetFeasibilityRiskAnalysises;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetFeasibilityRiskAnalysises;
using EduMS.Application.M4_AssetLogistics.Queries.AssetFeasibilityRiskAnalysises;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetFeasibilityRiskAnalysisesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetFeasibilityRiskAnalysisesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetFeasibilityRiskAnalysisDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAssetFeasibilityRiskAnalysisesQuery());
        return Ok(ApiResponse<IEnumerable<AssetFeasibilityRiskAnalysisDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetFeasibilityRiskAnalysisDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAssetFeasibilityRiskAnalysisByIdQuery { Id = id });
        return Ok(ApiResponse<AssetFeasibilityRiskAnalysisDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetFeasibilityRiskAnalysisDto dto)
    {
        var id = await _mediator.Send(new CreateAssetFeasibilityRiskAnalysisCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetFeasibilityRiskAnalysisDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAssetFeasibilityRiskAnalysisCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAssetFeasibilityRiskAnalysisCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}