using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.Employees;
using EduMS.Application.M3_EmployeeManagement.DTOs.Employees;
using EduMS.Application.M3_EmployeeManagement.Queries.Employees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.Employees.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEmployeesQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeDto>>.Success(result));
    }

    [HasPermission(Permissions.Employees.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEmployeeByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeDto>.Success(result));
    }

    [HasPermission(Permissions.Employees.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeDto dto)
    {
        var id = await sender.Send(new CreateEmployeeCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.Employees.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEmployeeCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.Employees.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEmployeeCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




