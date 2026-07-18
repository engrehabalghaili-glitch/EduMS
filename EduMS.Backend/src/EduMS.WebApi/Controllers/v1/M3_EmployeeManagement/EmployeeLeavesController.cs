using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeLeaves;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeLeaves;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeLeaves;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeLeavesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeLeavesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeLeaveDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllEmployeeLeavesQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeLeaveDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeLeaveDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetEmployeeLeaveByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeLeaveDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeLeaveDto dto)
    {
        var id = await _mediator.Send(new CreateEmployeeLeaveCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeLeaveDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateEmployeeLeaveCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteEmployeeLeaveCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}