using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentGuardianRelationships;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentGuardianRelationships;
using EduMS.Application.M2_StudentAffairs.Queries.StudentGuardianRelationships;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentGuardianRelationshipsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentGuardianRelationshipsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentGuardianRelationshipDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentGuardianRelationshipsQuery());
        return Ok(ApiResponse<IEnumerable<StudentGuardianRelationshipDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentGuardianRelationshipDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentGuardianRelationshipByIdQuery { Id = id });
        return Ok(ApiResponse<StudentGuardianRelationshipDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentGuardianRelationshipDto dto)
    {
        var id = await _mediator.Send(new CreateStudentGuardianRelationshipCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentGuardianRelationshipDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentGuardianRelationshipCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentGuardianRelationshipCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}