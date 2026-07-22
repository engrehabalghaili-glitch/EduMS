using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentTransportPreferences;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentTransportPreferences;
using EduMS.Application.M2_StudentAffairs.Queries.StudentTransportPreferences;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentTransportPreferencesController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentTransportPreferencesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentTransportPreferenceDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentTransportPreferencesQuery());
        return Ok(ApiResponse<IEnumerable<StudentTransportPreferenceDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentTransportPreferenceDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentTransportPreferenceByIdQuery { Id = id });
        return Ok(ApiResponse<StudentTransportPreferenceDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentTransportPreferenceDto dto)
    {
        var id = await _mediator.Send(new CreateStudentTransportPreferenceCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentTransportPreferenceDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentTransportPreferenceCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentTransportPreferenceCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}