using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetRequirementRequests;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetRequirementRequests;
using EduMS.Application.M4_AssetLogistics.Queries.AssetRequirementRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetRequirementRequestsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetRequirementRequestDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetRequirementRequestsQuery());
        return Ok(ApiResponse<IEnumerable<AssetRequirementRequestDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetRequirementRequestDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetRequirementRequestByIdQuery { Id = id });
        return Ok(ApiResponse<AssetRequirementRequestDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetRequirementRequestDto dto)
    {
        var id = await sender.Send(new CreateAssetRequirementRequestCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetRequirementRequestDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetRequirementRequestCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetRequirementRequestCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



