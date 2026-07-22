using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentDailyAttendanceSummaries;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentDailyAttendanceSummaries;
using EduMS.Application.M2_StudentAffairs.Queries.StudentDailyAttendanceSummaries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentDailyAttendanceSummariesController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentDailyAttendanceSummariesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentDailyAttendanceSummaryDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentDailyAttendanceSummariesQuery());
        return Ok(ApiResponse<IEnumerable<StudentDailyAttendanceSummaryDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentDailyAttendanceSummaryDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentDailyAttendanceSummaryByIdQuery { Id = id });
        return Ok(ApiResponse<StudentDailyAttendanceSummaryDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentDailyAttendanceSummaryDto dto)
    {
        var id = await _mediator.Send(new CreateStudentDailyAttendanceSummaryCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentDailyAttendanceSummaryDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentDailyAttendanceSummaryCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentDailyAttendanceSummaryCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}