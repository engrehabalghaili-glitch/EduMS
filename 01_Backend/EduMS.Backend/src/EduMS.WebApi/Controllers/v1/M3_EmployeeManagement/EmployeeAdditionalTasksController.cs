using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeAdditionalTasks;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeAdditionalTasks;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeAdditionalTasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeAdditionalTasksController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeAdditionalTaskDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEmployeeAdditionalTasksQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeAdditionalTaskDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeAdditionalTaskDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEmployeeAdditionalTaskByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeAdditionalTaskDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeAdditionalTaskDto dto)
    {
        var id = await sender.Send(new CreateEmployeeAdditionalTaskCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeAdditionalTaskDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEmployeeAdditionalTaskCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEmployeeAdditionalTaskCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



