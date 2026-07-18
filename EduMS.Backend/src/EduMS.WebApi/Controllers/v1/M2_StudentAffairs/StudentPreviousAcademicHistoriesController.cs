using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentPreviousAcademicHistories;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentPreviousAcademicHistories;
using EduMS.Application.M2_StudentAffairs.Queries.StudentPreviousAcademicHistories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentPreviousAcademicHistoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentPreviousAcademicHistoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentPreviousAcademicHistoryDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentPreviousAcademicHistoriesQuery());
        return Ok(ApiResponse<IEnumerable<StudentPreviousAcademicHistoryDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentPreviousAcademicHistoryDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentPreviousAcademicHistoryByIdQuery { Id = id });
        return Ok(ApiResponse<StudentPreviousAcademicHistoryDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentPreviousAcademicHistoryDto dto)
    {
        var id = await _mediator.Send(new CreateStudentPreviousAcademicHistoryCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentPreviousAcademicHistoryDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentPreviousAcademicHistoryCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentPreviousAcademicHistoryCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}