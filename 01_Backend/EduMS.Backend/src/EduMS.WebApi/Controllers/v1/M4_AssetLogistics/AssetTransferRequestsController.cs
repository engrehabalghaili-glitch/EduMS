using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetTransferRequests;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetTransferRequests;
using EduMS.Application.M4_AssetLogistics.Queries.AssetTransferRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetTransferRequestsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetTransferRequestDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetTransferRequestsQuery());
        return Ok(ApiResponse<IEnumerable<AssetTransferRequestDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetTransferRequestDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetTransferRequestByIdQuery { Id = id });
        return Ok(ApiResponse<AssetTransferRequestDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetTransferRequestDto dto)
    {
        var id = await sender.Send(new CreateAssetTransferRequestCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetTransferRequestDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetTransferRequestCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetTransferRequestCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



