using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentAssignmentSubmissions;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentAssignmentSubmissions;
using EduMS.Application.M2_StudentAffairs.Queries.StudentAssignmentSubmissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentAssignmentSubmissionsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentAssignmentSubmissions.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentAssignmentSubmissionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentAssignmentSubmissionsQuery());
        return Ok(ApiResponse<IEnumerable<StudentAssignmentSubmissionDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentAssignmentSubmissions.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentAssignmentSubmissionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentAssignmentSubmissionByIdQuery { Id = id });
        return Ok(ApiResponse<StudentAssignmentSubmissionDto>.Success(result));
    }

    [HasPermission(Permissions.StudentAssignmentSubmissions.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentAssignmentSubmissionDto dto)
    {
        var id = await sender.Send(new CreateStudentAssignmentSubmissionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentAssignmentSubmissions.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentAssignmentSubmissionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentAssignmentSubmissionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentAssignmentSubmissions.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentAssignmentSubmissionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




