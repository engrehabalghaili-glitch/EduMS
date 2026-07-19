using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetLoans;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetLoans;
using EduMS.Application.M4_AssetLogistics.Queries.AssetLoans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetLoansController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetLoansController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetLoanDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAssetLoansQuery());
        return Ok(ApiResponse<IEnumerable<AssetLoanDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetLoanDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAssetLoanByIdQuery { Id = id });
        return Ok(ApiResponse<AssetLoanDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetLoanDto dto)
    {
        var id = await _mediator.Send(new CreateAssetLoanCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetLoanDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAssetLoanCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAssetLoanCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}