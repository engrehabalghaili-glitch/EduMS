using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentActivityParticipations;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentActivityParticipations;
using EduMS.Application.M2_StudentAffairs.Queries.StudentActivityParticipations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentActivityParticipationsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentActivityParticipations.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentActivityParticipationDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentActivityParticipationsQuery());
        return Ok(ApiResponse<IEnumerable<StudentActivityParticipationDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentActivityParticipations.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentActivityParticipationDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentActivityParticipationByIdQuery { Id = id });
        return Ok(ApiResponse<StudentActivityParticipationDto>.Success(result));
    }

    [HasPermission(Permissions.StudentActivityParticipations.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentActivityParticipationDto dto)
    {
        var id = await sender.Send(new CreateStudentActivityParticipationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentActivityParticipations.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentActivityParticipationDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentActivityParticipationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentActivityParticipations.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentActivityParticipationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




