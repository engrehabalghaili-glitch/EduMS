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
public class StudentExtracurricularAchievementsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentExtracurricularAchievementsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentExtracurricularAchievementDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentExtracurricularAchievementsQuery());
        return Ok(ApiResponse<IEnumerable<StudentExtracurricularAchievementDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentExtracurricularAchievementDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentExtracurricularAchievementByIdQuery { Id = id });
        return Ok(ApiResponse<StudentExtracurricularAchievementDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentExtracurricularAchievementDto dto)
    {
        var id = await _mediator.Send(new CreateStudentExtracurricularAchievementCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentExtracurricularAchievementDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentExtracurricularAchievementCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentExtracurricularAchievementCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}