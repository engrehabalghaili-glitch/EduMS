using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetLocationRecords;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetLocationRecords;
using EduMS.Application.M4_AssetLogistics.Queries.AssetLocationRecords;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetLocationRecordsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetLocationRecordDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetLocationRecordsQuery());
        return Ok(ApiResponse<IEnumerable<AssetLocationRecordDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetLocationRecordDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetLocationRecordByIdQuery { Id = id });
        return Ok(ApiResponse<AssetLocationRecordDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetLocationRecordDto dto)
    {
        var id = await sender.Send(new CreateAssetLocationRecordCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetLocationRecordDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetLocationRecordCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetLocationRecordCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



