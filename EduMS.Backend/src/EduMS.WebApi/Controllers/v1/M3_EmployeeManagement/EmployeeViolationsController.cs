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
public class EmployeeViolationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeViolationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeViolationDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllEmployeeViolationsQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeViolationDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeViolationDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetEmployeeViolationByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeViolationDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeViolationDto dto)
    {
        var id = await _mediator.Send(new CreateEmployeeViolationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeViolationDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateEmployeeViolationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteEmployeeViolationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}