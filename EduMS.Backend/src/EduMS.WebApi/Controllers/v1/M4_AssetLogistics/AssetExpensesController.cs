using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetExpenses;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetExpenses;
using EduMS.Application.M4_AssetLogistics.Queries.AssetExpenses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetExpensesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetExpensesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetExpenseDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAssetExpensesQuery());
        return Ok(ApiResponse<IEnumerable<AssetExpenseDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetExpenseDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAssetExpenseByIdQuery { Id = id });
        return Ok(ApiResponse<AssetExpenseDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetExpenseDto dto)
    {
        var id = await _mediator.Send(new CreateAssetExpenseCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetExpenseDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAssetExpenseCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAssetExpenseCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}