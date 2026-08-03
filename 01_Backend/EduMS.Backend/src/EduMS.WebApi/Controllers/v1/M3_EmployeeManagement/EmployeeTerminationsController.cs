using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeTerminations;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeTerminations;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeTerminations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeTerminationsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.EmployeeTerminations.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeTerminationDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEmployeeTerminationsQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeTerminationDto>>.Success(result));
    }

    [HasPermission(Permissions.EmployeeTerminations.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeTerminationDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEmployeeTerminationByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeTerminationDto>.Success(result));
    }

    [HasPermission(Permissions.EmployeeTerminations.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeTerminationDto dto)
    {
        var id = await sender.Send(new CreateEmployeeTerminationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.EmployeeTerminations.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeTerminationDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEmployeeTerminationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.EmployeeTerminations.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEmployeeTerminationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




