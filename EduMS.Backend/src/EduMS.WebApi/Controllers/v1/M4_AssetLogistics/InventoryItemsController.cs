using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.InventoryItems;
using EduMS.Application.M4_AssetLogistics.DTOs.InventoryItems;
using EduMS.Application.M4_AssetLogistics.Queries.InventoryItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class InventoryItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoryItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<InventoryItemDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllInventoryItemsQuery());
        return Ok(ApiResponse<IEnumerable<InventoryItemDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<InventoryItemDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetInventoryItemByIdQuery { Id = id });
        return Ok(ApiResponse<InventoryItemDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateInventoryItemDto dto)
    {
        var id = await _mediator.Send(new CreateInventoryItemCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateInventoryItemDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateInventoryItemCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteInventoryItemCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}