using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentAdmissionApplications;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentAdmissionApplications;
using EduMS.Application.M2_StudentAffairs.Queries.StudentAdmissionApplications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentAdmissionApplicationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentAdmissionApplicationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentAdmissionApplicationDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentAdmissionApplicationsQuery());
        return Ok(ApiResponse<IEnumerable<StudentAdmissionApplicationDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentAdmissionApplicationDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentAdmissionApplicationByIdQuery { Id = id });
        return Ok(ApiResponse<StudentAdmissionApplicationDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentAdmissionApplicationDto dto)
    {
        var id = await _mediator.Send(new CreateStudentAdmissionApplicationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentAdmissionApplicationDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentAdmissionApplicationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentAdmissionApplicationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}