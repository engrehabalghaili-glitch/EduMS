using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeCommittees;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeCommittees;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeCommittees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeCommitteesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.EmployeeCommittees.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeCommitteeDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEmployeeCommitteesQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeCommitteeDto>>.Success(result));
    }

    [HasPermission(Permissions.EmployeeCommittees.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeCommitteeDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEmployeeCommitteeByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeCommitteeDto>.Success(result));
    }

    [HasPermission(Permissions.EmployeeCommittees.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeCommitteeDto dto)
    {
        var id = await sender.Send(new CreateEmployeeCommitteeCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.EmployeeCommittees.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeCommitteeDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEmployeeCommitteeCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.EmployeeCommittees.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEmployeeCommitteeCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




