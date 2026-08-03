using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetStatusRecords;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetStatusRecords;
using EduMS.Application.M4_AssetLogistics.Queries.AssetStatusRecords;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetStatusRecordsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetStatusRecords.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetStatusRecordDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetStatusRecordsQuery());
        return Ok(ApiResponse<IEnumerable<AssetStatusRecordDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetStatusRecords.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetStatusRecordDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetStatusRecordByIdQuery { Id = id });
        return Ok(ApiResponse<AssetStatusRecordDto>.Success(result));
    }

    [HasPermission(Permissions.AssetStatusRecords.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetStatusRecordDto dto)
    {
        var id = await sender.Send(new CreateAssetStatusRecordCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetStatusRecords.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetStatusRecordDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetStatusRecordCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetStatusRecords.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetStatusRecordCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




