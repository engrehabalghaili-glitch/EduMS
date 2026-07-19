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
public class DepreciationTransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepreciationTransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<DepreciationTransactionDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllDepreciationTransactionsQuery());
        return Ok(ApiResponse<IEnumerable<DepreciationTransactionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<DepreciationTransactionDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetDepreciationTransactionByIdQuery { Id = id });
        return Ok(ApiResponse<DepreciationTransactionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateDepreciationTransactionDto dto)
    {
        var id = await _mediator.Send(new CreateDepreciationTransactionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateDepreciationTransactionDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateDepreciationTransactionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteDepreciationTransactionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}