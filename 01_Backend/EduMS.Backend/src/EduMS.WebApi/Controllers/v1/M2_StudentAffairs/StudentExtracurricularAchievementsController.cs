using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentExtracurricularAchievements;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentExtracurricularAchievements;
using EduMS.Application.M2_StudentAffairs.Queries.StudentExtracurricularAchievements;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentExtracurricularAchievementsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentExtracurricularAchievements.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentExtracurricularAchievementDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentExtracurricularAchievementsQuery());
        return Ok(ApiResponse<IEnumerable<StudentExtracurricularAchievementDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentExtracurricularAchievements.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentExtracurricularAchievementDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentExtracurricularAchievementByIdQuery { Id = id });
        return Ok(ApiResponse<StudentExtracurricularAchievementDto>.Success(result));
    }

    [HasPermission(Permissions.StudentExtracurricularAchievements.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentExtracurricularAchievementDto dto)
    {
        var id = await sender.Send(new CreateStudentExtracurricularAchievementCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentExtracurricularAchievements.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentExtracurricularAchievementDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentExtracurricularAchievementCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentExtracurricularAchievements.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentExtracurricularAchievementCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




