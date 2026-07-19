using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.FeeInstallments;
using EduMS.Application.M5_FinancialManagement.DTOs.FeeInstallments;
using EduMS.Application.M5_FinancialManagement.Queries.FeeInstallments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class FeeInstallmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FeeInstallmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<FeeInstallmentDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllFeeInstallmentsQuery());
        return Ok(ApiResponse<IEnumerable<FeeInstallmentDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<FeeInstallmentDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetFeeInstallmentByIdQuery { Id = id });
        return Ok(ApiResponse<FeeInstallmentDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateFeeInstallmentDto dto)
    {
        var id = await _mediator.Send(new CreateFeeInstallmentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateFeeInstallmentDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateFeeInstallmentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteFeeInstallmentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}