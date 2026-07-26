using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetAuditFinalApprovals;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetAuditFinalApprovals;
using EduMS.Application.M4_AssetLogistics.Queries.AssetAuditFinalApprovals;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetAuditFinalApprovalsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetAuditFinalApprovalDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetAuditFinalApprovalsQuery());
        return Ok(ApiResponse<IEnumerable<AssetAuditFinalApprovalDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetAuditFinalApprovalDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetAuditFinalApprovalByIdQuery { Id = id });
        return Ok(ApiResponse<AssetAuditFinalApprovalDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetAuditFinalApprovalDto dto)
    {
        var id = await sender.Send(new CreateAssetAuditFinalApprovalCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetAuditFinalApprovalDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetAuditFinalApprovalCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetAuditFinalApprovalCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



