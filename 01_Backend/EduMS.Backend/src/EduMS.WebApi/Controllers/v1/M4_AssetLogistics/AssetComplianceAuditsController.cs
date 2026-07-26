using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetComplianceAudits;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetComplianceAudits;
using EduMS.Application.M4_AssetLogistics.Queries.AssetComplianceAudits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetComplianceAuditsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetComplianceAuditDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetComplianceAuditsQuery());
        return Ok(ApiResponse<IEnumerable<AssetComplianceAuditDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetComplianceAuditDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetComplianceAuditByIdQuery { Id = id });
        return Ok(ApiResponse<AssetComplianceAuditDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetComplianceAuditDto dto)
    {
        var id = await sender.Send(new CreateAssetComplianceAuditCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetComplianceAuditDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetComplianceAuditCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetComplianceAuditCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



