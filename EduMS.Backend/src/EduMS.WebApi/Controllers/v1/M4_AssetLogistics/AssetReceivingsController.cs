using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetReceivings;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetReceivings;
using EduMS.Application.M4_AssetLogistics.Queries.AssetReceivings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetReceivingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetReceivingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetReceivingDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAssetReceivingsQuery());
        return Ok(ApiResponse<IEnumerable<AssetReceivingDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetReceivingDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAssetReceivingByIdQuery { Id = id });
        return Ok(ApiResponse<AssetReceivingDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetReceivingDto dto)
    {
        var id = await _mediator.Send(new CreateAssetReceivingCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetReceivingDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAssetReceivingCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAssetReceivingCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}