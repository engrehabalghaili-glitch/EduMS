using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.PurchaseOrders;
using EduMS.Application.M4_AssetLogistics.DTOs.PurchaseOrders;
using EduMS.Application.M4_AssetLogistics.Queries.PurchaseOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class PurchaseOrdersController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<PurchaseOrderDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllPurchaseOrdersQuery());
        return Ok(ApiResponse<IEnumerable<PurchaseOrderDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<PurchaseOrderDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetPurchaseOrderByIdQuery { Id = id });
        return Ok(ApiResponse<PurchaseOrderDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreatePurchaseOrderDto dto)
    {
        var id = await sender.Send(new CreatePurchaseOrderCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdatePurchaseOrderDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdatePurchaseOrderCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeletePurchaseOrderCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



