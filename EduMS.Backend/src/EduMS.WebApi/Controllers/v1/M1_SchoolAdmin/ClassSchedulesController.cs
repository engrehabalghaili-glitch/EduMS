using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.ClassSchedules;
using EduMS.Application.M1_SchoolAdmin.DTOs.ClassSchedules;
using EduMS.Application.M1_SchoolAdmin.Queries.ClassSchedules;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ClassSchedulesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClassSchedulesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ClassScheduleDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllClassSchedulesQuery());
        return Ok(ApiResponse<IEnumerable<ClassScheduleDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ClassScheduleDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetClassScheduleByIdQuery { Id = id });
        return Ok(ApiResponse<ClassScheduleDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateClassScheduleDto dto)
    {
        var id = await _mediator.Send(new CreateClassScheduleCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateClassScheduleDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateClassScheduleCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteClassScheduleCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}