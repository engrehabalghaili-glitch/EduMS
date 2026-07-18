using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentMedicalAllergyLogs;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentMedicalAllergyLogs;
using EduMS.Application.M2_StudentAffairs.Queries.StudentMedicalAllergyLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentMedicalAllergyLogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentMedicalAllergyLogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentMedicalAllergyLogDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentMedicalAllergyLogsQuery());
        return Ok(ApiResponse<IEnumerable<StudentMedicalAllergyLogDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentMedicalAllergyLogDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentMedicalAllergyLogByIdQuery { Id = id });
        return Ok(ApiResponse<StudentMedicalAllergyLogDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentMedicalAllergyLogDto dto)
    {
        var id = await _mediator.Send(new CreateStudentMedicalAllergyLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentMedicalAllergyLogDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentMedicalAllergyLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentMedicalAllergyLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}