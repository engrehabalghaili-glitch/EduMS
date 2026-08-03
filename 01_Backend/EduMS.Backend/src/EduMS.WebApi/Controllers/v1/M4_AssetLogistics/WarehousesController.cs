using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.Warehouses;
using EduMS.Application.M4_AssetLogistics.DTOs.Warehouses;
using EduMS.Application.M4_AssetLogistics.Queries.Warehouses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class WarehousesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.Warehouses.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<WarehouseDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllWarehousesQuery());
        return Ok(ApiResponse<IEnumerable<WarehouseDto>>.Success(result));
    }

    [HasPermission(Permissions.Warehouses.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<WarehouseDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetWarehouseByIdQuery { Id = id });
        return Ok(ApiResponse<WarehouseDto>.Success(result));
    }

    [HasPermission(Permissions.Warehouses.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateWarehouseDto dto)
    {
        var id = await sender.Send(new CreateWarehouseCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.Warehouses.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateWarehouseDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateWarehouseCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.Warehouses.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteWarehouseCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




