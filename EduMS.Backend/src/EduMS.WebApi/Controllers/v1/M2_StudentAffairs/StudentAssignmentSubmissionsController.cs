using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentAssignmentSubmissions;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentAssignmentSubmissions;
using EduMS.Application.M2_StudentAffairs.Queries.StudentAssignmentSubmissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentAssignmentSubmissionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentAssignmentSubmissionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentAssignmentSubmissionDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentAssignmentSubmissionsQuery());
        return Ok(ApiResponse<IEnumerable<StudentAssignmentSubmissionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentAssignmentSubmissionDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentAssignmentSubmissionByIdQuery { Id = id });
        return Ok(ApiResponse<StudentAssignmentSubmissionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentAssignmentSubmissionDto dto)
    {
        var id = await _mediator.Send(new CreateStudentAssignmentSubmissionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentAssignmentSubmissionDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentAssignmentSubmissionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentAssignmentSubmissionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}