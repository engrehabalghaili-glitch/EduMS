using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.ExamDistributionTimetables;
using EduMS.Application.M1_SchoolAdmin.DTOs.ExamDistributionTimetables;
using EduMS.Application.M1_SchoolAdmin.Queries.ExamDistributionTimetables;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ExamDistributionTimetablesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExamDistributionTimetablesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ExamDistributionTimetableDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllExamDistributionTimetablesQuery());
        return Ok(ApiResponse<IEnumerable<ExamDistributionTimetableDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ExamDistributionTimetableDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetExamDistributionTimetableByIdQuery { Id = id });
        return Ok(ApiResponse<ExamDistributionTimetableDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateExamDistributionTimetableDto dto)
    {
        var id = await _mediator.Send(new CreateExamDistributionTimetableCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateExamDistributionTimetableDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateExamDistributionTimetableCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteExamDistributionTimetableCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}