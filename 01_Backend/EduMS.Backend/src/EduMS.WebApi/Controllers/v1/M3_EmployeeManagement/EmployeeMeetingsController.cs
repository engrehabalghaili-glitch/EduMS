using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeMeetings;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeMeetings;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeMeetings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeMeetingsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeMeetingDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEmployeeMeetingsQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeMeetingDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeMeetingDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEmployeeMeetingByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeMeetingDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeMeetingDto dto)
    {
        var id = await sender.Send(new CreateEmployeeMeetingCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeMeetingDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEmployeeMeetingCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEmployeeMeetingCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



