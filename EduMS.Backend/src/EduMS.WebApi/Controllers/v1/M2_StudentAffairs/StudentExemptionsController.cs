using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentExemptions;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentExemptions;
using EduMS.Application.M2_StudentAffairs.Queries.StudentExemptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentExemptionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentExemptionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentExemptionDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentExemptionsQuery());
        return Ok(ApiResponse<IEnumerable<StudentExemptionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentExemptionDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentExemptionByIdQuery { Id = id });
        return Ok(ApiResponse<StudentExemptionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentExemptionDto dto)
    {
        var id = await _mediator.Send(new CreateStudentExemptionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentExemptionDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentExemptionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentExemptionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}