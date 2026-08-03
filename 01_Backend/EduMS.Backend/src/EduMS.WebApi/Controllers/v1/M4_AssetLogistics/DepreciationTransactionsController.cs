using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.DepreciationTransactions;
using EduMS.Application.M4_AssetLogistics.DTOs.DepreciationTransactions;
using EduMS.Application.M4_AssetLogistics.Queries.DepreciationTransactions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class DepreciationTransactionsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.DepreciationTransactions.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<DepreciationTransactionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllDepreciationTransactionsQuery());
        return Ok(ApiResponse<IEnumerable<DepreciationTransactionDto>>.Success(result));
    }

    [HasPermission(Permissions.DepreciationTransactions.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<DepreciationTransactionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetDepreciationTransactionByIdQuery { Id = id });
        return Ok(ApiResponse<DepreciationTransactionDto>.Success(result));
    }

    [HasPermission(Permissions.DepreciationTransactions.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateDepreciationTransactionDto dto)
    {
        var id = await sender.Send(new CreateDepreciationTransactionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.DepreciationTransactions.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateDepreciationTransactionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateDepreciationTransactionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.DepreciationTransactions.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteDepreciationTransactionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




