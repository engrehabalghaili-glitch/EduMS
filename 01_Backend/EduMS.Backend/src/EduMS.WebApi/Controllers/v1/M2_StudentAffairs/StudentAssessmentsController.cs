using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentAssessments;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentAssessments;
using EduMS.Application.M2_StudentAffairs.Queries.StudentAssessments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentAssessmentsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentAssessments.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentAssessmentDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentAssessmentsQuery());
        return Ok(ApiResponse<IEnumerable<StudentAssessmentDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentAssessments.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentAssessmentDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentAssessmentByIdQuery { Id = id });
        return Ok(ApiResponse<StudentAssessmentDto>.Success(result));
    }

    [HasPermission(Permissions.StudentAssessments.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentAssessmentDto dto)
    {
        var id = await sender.Send(new CreateStudentAssessmentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentAssessments.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentAssessmentDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentAssessmentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentAssessments.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentAssessmentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




