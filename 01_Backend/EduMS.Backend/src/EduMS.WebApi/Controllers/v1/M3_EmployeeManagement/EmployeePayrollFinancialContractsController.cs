using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeePayrollFinancialContracts;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePayrollFinancialContracts;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeePayrollFinancialContracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeePayrollFinancialContractsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeePayrollFinancialContractDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEmployeePayrollFinancialContractsQuery());
        return Ok(ApiResponse<IEnumerable<EmployeePayrollFinancialContractDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeePayrollFinancialContractDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEmployeePayrollFinancialContractByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeePayrollFinancialContractDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeePayrollFinancialContractDto dto)
    {
        var id = await sender.Send(new CreateEmployeePayrollFinancialContractCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeePayrollFinancialContractDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEmployeePayrollFinancialContractCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEmployeePayrollFinancialContractCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



