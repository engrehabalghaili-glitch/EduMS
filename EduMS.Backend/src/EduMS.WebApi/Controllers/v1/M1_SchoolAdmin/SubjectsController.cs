using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.Subjects;
using EduMS.Application.M1_SchoolAdmin.DTOs.Subjects;
using EduMS.Application.M1_SchoolAdmin.Queries.Subjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SubjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SubjectDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSubjectsQuery());
        return Ok(ApiResponse<IEnumerable<SubjectDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SubjectDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSubjectByIdQuery { Id = id });
        return Ok(ApiResponse<SubjectDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSubjectDto dto)
    {
        var id = await _mediator.Send(new CreateSubjectCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSubjectDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateSubjectCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteSubjectCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}