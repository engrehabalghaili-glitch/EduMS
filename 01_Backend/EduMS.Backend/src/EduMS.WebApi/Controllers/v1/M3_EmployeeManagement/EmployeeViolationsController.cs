using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeViolations;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeViolations;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeViolations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeViolationsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.EmployeeViolations.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeViolationDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEmployeeViolationsQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeViolationDto>>.Success(result));
    }

    [HasPermission(Permissions.EmployeeViolations.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeViolationDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEmployeeViolationByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeViolationDto>.Success(result));
    }

    [HasPermission(Permissions.EmployeeViolations.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeViolationDto dto)
    {
        var id = await sender.Send(new CreateEmployeeViolationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.EmployeeViolations.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeViolationDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEmployeeViolationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.EmployeeViolations.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEmployeeViolationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




