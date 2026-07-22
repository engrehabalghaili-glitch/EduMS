using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.InventoryReconciliations;
using EduMS.Application.M4_AssetLogistics.DTOs.InventoryReconciliations;
using EduMS.Application.M4_AssetLogistics.Queries.InventoryReconciliations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class InventoryReconciliationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoryReconciliationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<InventoryReconciliationDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllInventoryReconciliationsQuery());
        return Ok(ApiResponse<IEnumerable<InventoryReconciliationDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<InventoryReconciliationDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetInventoryReconciliationByIdQuery { Id = id });
        return Ok(ApiResponse<InventoryReconciliationDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateInventoryReconciliationDto dto)
    {
        var id = await _mediator.Send(new CreateInventoryReconciliationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateInventoryReconciliationDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateInventoryReconciliationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteInventoryReconciliationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}