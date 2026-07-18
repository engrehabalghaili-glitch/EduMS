using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentAbsenceExcusals;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentAbsenceExcusals;
using EduMS.Application.M2_StudentAffairs.Queries.StudentAbsenceExcusals;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentAbsenceExcusalsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentAbsenceExcusalsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentAbsenceExcusalDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentAbsenceExcusalsQuery());
        return Ok(ApiResponse<IEnumerable<StudentAbsenceExcusalDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentAbsenceExcusalDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentAbsenceExcusalByIdQuery { Id = id });
        return Ok(ApiResponse<StudentAbsenceExcusalDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentAbsenceExcusalDto dto)
    {
        var id = await _mediator.Send(new CreateStudentAbsenceExcusalCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentAbsenceExcusalDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentAbsenceExcusalCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentAbsenceExcusalCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}