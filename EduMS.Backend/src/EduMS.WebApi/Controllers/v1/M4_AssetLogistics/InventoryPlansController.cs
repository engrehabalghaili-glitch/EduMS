using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.InventoryPlans;
using EduMS.Application.M4_AssetLogistics.DTOs.InventoryPlans;
using EduMS.Application.M4_AssetLogistics.Queries.InventoryPlans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class InventoryPlansController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoryPlansController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<InventoryPlanDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllInventoryPlansQuery());
        return Ok(ApiResponse<IEnumerable<InventoryPlanDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<InventoryPlanDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetInventoryPlanByIdQuery { Id = id });
        return Ok(ApiResponse<InventoryPlanDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateInventoryPlanDto dto)
    {
        var id = await _mediator.Send(new CreateInventoryPlanCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateInventoryPlanDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateInventoryPlanCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteInventoryPlanCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}