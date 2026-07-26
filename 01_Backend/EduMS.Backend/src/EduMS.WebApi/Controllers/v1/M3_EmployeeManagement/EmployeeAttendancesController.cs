using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeAttendances;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeAttendances;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeAttendances;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeAttendancesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeAttendanceDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEmployeeAttendancesQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeAttendanceDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeAttendanceDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEmployeeAttendanceByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeAttendanceDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeAttendanceDto dto)
    {
        var id = await sender.Send(new CreateEmployeeAttendanceCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeAttendanceDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEmployeeAttendanceCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEmployeeAttendanceCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



