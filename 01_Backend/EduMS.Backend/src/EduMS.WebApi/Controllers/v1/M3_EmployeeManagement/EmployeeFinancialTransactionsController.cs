using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
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
public class EmployeeFinancialTransactionsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.EmployeeFinancialTransactions.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeFinancialTransactionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEmployeeFinancialTransactionsQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeFinancialTransactionDto>>.Success(result));
    }

    [HasPermission(Permissions.EmployeeFinancialTransactions.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeFinancialTransactionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEmployeeFinancialTransactionByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeFinancialTransactionDto>.Success(result));
    }

    [HasPermission(Permissions.EmployeeFinancialTransactions.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeFinancialTransactionDto dto)
    {
        var id = await sender.Send(new CreateEmployeeFinancialTransactionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.EmployeeFinancialTransactions.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeFinancialTransactionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEmployeeFinancialTransactionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.EmployeeFinancialTransactions.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEmployeeFinancialTransactionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




