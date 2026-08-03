using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentPsychologicalCounselingLogs;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentPsychologicalCounselingLogs;
using EduMS.Application.M2_StudentAffairs.Queries.StudentPsychologicalCounselingLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentPsychologicalCounselingLogsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentPsychologicalCounselingLogs.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentPsychologicalCounselingLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentPsychologicalCounselingLogsQuery());
        return Ok(ApiResponse<IEnumerable<StudentPsychologicalCounselingLogDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentPsychologicalCounselingLogs.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentPsychologicalCounselingLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentPsychologicalCounselingLogByIdQuery { Id = id });
        return Ok(ApiResponse<StudentPsychologicalCounselingLogDto>.Success(result));
    }

    [HasPermission(Permissions.StudentPsychologicalCounselingLogs.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentPsychologicalCounselingLogDto dto)
    {
        var id = await sender.Send(new CreateStudentPsychologicalCounselingLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentPsychologicalCounselingLogs.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentPsychologicalCounselingLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentPsychologicalCounselingLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentPsychologicalCounselingLogs.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentPsychologicalCounselingLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




