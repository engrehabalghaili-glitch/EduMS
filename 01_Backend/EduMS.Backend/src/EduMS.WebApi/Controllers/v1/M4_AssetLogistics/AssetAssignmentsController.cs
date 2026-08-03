using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetAssignments;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetAssignments;
using EduMS.Application.M4_AssetLogistics.Queries.AssetAssignments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetAssignmentsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetAssignments.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetAssignmentDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetAssignmentsQuery());
        return Ok(ApiResponse<IEnumerable<AssetAssignmentDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetAssignments.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetAssignmentDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetAssignmentByIdQuery { Id = id });
        return Ok(ApiResponse<AssetAssignmentDto>.Success(result));
    }

    [HasPermission(Permissions.AssetAssignments.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetAssignmentDto dto)
    {
        var id = await sender.Send(new CreateAssetAssignmentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetAssignments.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetAssignmentDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetAssignmentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetAssignments.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetAssignmentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




