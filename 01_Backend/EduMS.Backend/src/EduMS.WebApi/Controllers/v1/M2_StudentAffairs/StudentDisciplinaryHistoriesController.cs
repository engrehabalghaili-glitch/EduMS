using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentDisciplinaryHistories;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentDisciplinaryHistories;
using EduMS.Application.M2_StudentAffairs.Queries.StudentDisciplinaryHistories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentDisciplinaryHistoriesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentDisciplinaryHistories.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentDisciplinaryHistoryDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentDisciplinaryHistoriesQuery());
        return Ok(ApiResponse<IEnumerable<StudentDisciplinaryHistoryDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentDisciplinaryHistories.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentDisciplinaryHistoryDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentDisciplinaryHistoryByIdQuery { Id = id });
        return Ok(ApiResponse<StudentDisciplinaryHistoryDto>.Success(result));
    }

    [HasPermission(Permissions.StudentDisciplinaryHistories.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentDisciplinaryHistoryDto dto)
    {
        var id = await sender.Send(new CreateStudentDisciplinaryHistoryCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentDisciplinaryHistories.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentDisciplinaryHistoryDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentDisciplinaryHistoryCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentDisciplinaryHistories.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentDisciplinaryHistoryCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




