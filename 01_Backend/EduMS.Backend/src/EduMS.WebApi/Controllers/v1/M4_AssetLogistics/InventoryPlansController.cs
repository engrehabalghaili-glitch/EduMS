using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
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
public class InventoryPlansController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.InventoryPlans.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<InventoryPlanDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllInventoryPlansQuery());
        return Ok(ApiResponse<IEnumerable<InventoryPlanDto>>.Success(result));
    }

    [HasPermission(Permissions.InventoryPlans.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<InventoryPlanDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetInventoryPlanByIdQuery { Id = id });
        return Ok(ApiResponse<InventoryPlanDto>.Success(result));
    }

    [HasPermission(Permissions.InventoryPlans.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateInventoryPlanDto dto)
    {
        var id = await sender.Send(new CreateInventoryPlanCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.InventoryPlans.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateInventoryPlanDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateInventoryPlanCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.InventoryPlans.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteInventoryPlanCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




