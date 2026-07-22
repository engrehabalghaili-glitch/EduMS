using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeMentors;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeMentors;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeMentors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeMentorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeMentorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeMentorDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllEmployeeMentorsQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeMentorDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeMentorDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetEmployeeMentorByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeMentorDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeMentorDto dto)
    {
        var id = await _mediator.Send(new CreateEmployeeMentorCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeMentorDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateEmployeeMentorCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteEmployeeMentorCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}