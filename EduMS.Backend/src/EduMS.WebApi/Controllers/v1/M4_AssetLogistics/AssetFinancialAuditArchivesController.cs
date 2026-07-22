using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetFinancialAuditArchives;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialAuditArchives;
using EduMS.Application.M4_AssetLogistics.Queries.AssetFinancialAuditArchives;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetFinancialAuditArchivesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetFinancialAuditArchivesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetFinancialAuditArchiveDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAssetFinancialAuditArchivesQuery());
        return Ok(ApiResponse<IEnumerable<AssetFinancialAuditArchiveDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetFinancialAuditArchiveDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAssetFinancialAuditArchiveByIdQuery { Id = id });
        return Ok(ApiResponse<AssetFinancialAuditArchiveDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetFinancialAuditArchiveDto dto)
    {
        var id = await _mediator.Send(new CreateAssetFinancialAuditArchiveCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetFinancialAuditArchiveDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAssetFinancialAuditArchiveCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAssetFinancialAuditArchiveCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}