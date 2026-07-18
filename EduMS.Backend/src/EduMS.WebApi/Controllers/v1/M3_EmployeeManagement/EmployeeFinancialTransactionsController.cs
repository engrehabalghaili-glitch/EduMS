using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeFinancialTransactions;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeFinancialTransactions;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeFinancialTransactions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeFinancialTransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeFinancialTransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeFinancialTransactionDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllEmployeeFinancialTransactionsQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeFinancialTransactionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeFinancialTransactionDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetEmployeeFinancialTransactionByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeFinancialTransactionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeFinancialTransactionDto dto)
    {
        var id = await _mediator.Send(new CreateEmployeeFinancialTransactionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeFinancialTransactionDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateEmployeeFinancialTransactionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteEmployeeFinancialTransactionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}