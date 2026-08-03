using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
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
public class AssetFinancialAuditArchivesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetFinancialAuditArchives.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetFinancialAuditArchiveDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetFinancialAuditArchivesQuery());
        return Ok(ApiResponse<IEnumerable<AssetFinancialAuditArchiveDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetFinancialAuditArchives.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetFinancialAuditArchiveDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetFinancialAuditArchiveByIdQuery { Id = id });
        return Ok(ApiResponse<AssetFinancialAuditArchiveDto>.Success(result));
    }

    [HasPermission(Permissions.AssetFinancialAuditArchives.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetFinancialAuditArchiveDto dto)
    {
        var id = await sender.Send(new CreateAssetFinancialAuditArchiveCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetFinancialAuditArchives.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetFinancialAuditArchiveDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetFinancialAuditArchiveCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetFinancialAuditArchives.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetFinancialAuditArchiveCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




