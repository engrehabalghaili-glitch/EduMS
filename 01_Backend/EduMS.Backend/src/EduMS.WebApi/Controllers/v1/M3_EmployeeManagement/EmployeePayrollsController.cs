using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeePayrolls;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePayrolls;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeePayrolls;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeePayrollsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeePayrollDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEmployeePayrollsQuery());
        return Ok(ApiResponse<IEnumerable<EmployeePayrollDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeePayrollDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEmployeePayrollByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeePayrollDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeePayrollDto dto)
    {
        var id = await sender.Send(new CreateEmployeePayrollCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeePayrollDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEmployeePayrollCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEmployeePayrollCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



