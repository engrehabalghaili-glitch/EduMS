using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentEnrollments;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentEnrollments;
using EduMS.Application.M2_StudentAffairs.Queries.StudentEnrollments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentEnrollmentsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentEnrollments.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentEnrollmentDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentEnrollmentsQuery());
        return Ok(ApiResponse<IEnumerable<StudentEnrollmentDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentEnrollments.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentEnrollmentDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentEnrollmentByIdQuery { Id = id });
        return Ok(ApiResponse<StudentEnrollmentDto>.Success(result));
    }

    [HasPermission(Permissions.StudentEnrollments.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentEnrollmentDto dto)
    {
        var id = await sender.Send(new CreateStudentEnrollmentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentEnrollments.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentEnrollmentDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentEnrollmentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentEnrollments.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentEnrollmentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




