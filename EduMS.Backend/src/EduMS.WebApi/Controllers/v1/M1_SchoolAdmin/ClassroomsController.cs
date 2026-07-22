using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.Classrooms;
using EduMS.Application.M1_SchoolAdmin.DTOs.Classrooms;
using EduMS.Application.M1_SchoolAdmin.Queries.Classrooms;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ClassroomsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClassroomsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ClassroomDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllClassroomsQuery());
        return Ok(ApiResponse<IEnumerable<ClassroomDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ClassroomDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetClassroomByIdQuery { Id = id });
        return Ok(ApiResponse<ClassroomDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateClassroomDto dto)
    {
        var id = await _mediator.Send(new CreateClassroomCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateClassroomDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateClassroomCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteClassroomCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}