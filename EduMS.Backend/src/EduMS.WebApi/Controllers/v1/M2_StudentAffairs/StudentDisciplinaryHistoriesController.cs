using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentDisciplinaryHistories;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentDisciplinaryHistories;
using EduMS.Application.M2_StudentAffairs.Queries.StudentDisciplinaryHistories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentDisciplinaryHistoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentDisciplinaryHistoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentDisciplinaryHistoryDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentDisciplinaryHistoriesQuery());
        return Ok(ApiResponse<IEnumerable<StudentDisciplinaryHistoryDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentDisciplinaryHistoryDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentDisciplinaryHistoryByIdQuery { Id = id });
        return Ok(ApiResponse<StudentDisciplinaryHistoryDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentDisciplinaryHistoryDto dto)
    {
        var id = await _mediator.Send(new CreateStudentDisciplinaryHistoryCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentDisciplinaryHistoryDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentDisciplinaryHistoryCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentDisciplinaryHistoryCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}