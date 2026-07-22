using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetFinancialSummaryReports;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialSummaryReports;
using EduMS.Application.M4_AssetLogistics.Queries.AssetFinancialSummaryReports;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetFinancialSummaryReportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetFinancialSummaryReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetFinancialSummaryReportDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAssetFinancialSummaryReportsQuery());
        return Ok(ApiResponse<IEnumerable<AssetFinancialSummaryReportDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetFinancialSummaryReportDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAssetFinancialSummaryReportByIdQuery { Id = id });
        return Ok(ApiResponse<AssetFinancialSummaryReportDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetFinancialSummaryReportDto dto)
    {
        var id = await _mediator.Send(new CreateAssetFinancialSummaryReportCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetFinancialSummaryReportDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAssetFinancialSummaryReportCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAssetFinancialSummaryReportCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}