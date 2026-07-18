using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeTrainings;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeTrainings;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeTrainings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeTrainingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeTrainingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeTrainingDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllEmployeeTrainingsQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeTrainingDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeTrainingDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetEmployeeTrainingByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeTrainingDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeTrainingDto dto)
    {
        var id = await _mediator.Send(new CreateEmployeeTrainingCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeTrainingDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateEmployeeTrainingCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteEmployeeTrainingCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}