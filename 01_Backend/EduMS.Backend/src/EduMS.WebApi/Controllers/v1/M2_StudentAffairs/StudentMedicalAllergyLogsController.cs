using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
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
public class StudentMedicalAllergyLogsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentMedicalAllergyLogs.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentMedicalAllergyLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentMedicalAllergyLogsQuery());
        return Ok(ApiResponse<IEnumerable<StudentMedicalAllergyLogDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentMedicalAllergyLogs.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentMedicalAllergyLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentMedicalAllergyLogByIdQuery { Id = id });
        return Ok(ApiResponse<StudentMedicalAllergyLogDto>.Success(result));
    }

    [HasPermission(Permissions.StudentMedicalAllergyLogs.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentMedicalAllergyLogDto dto)
    {
        var id = await sender.Send(new CreateStudentMedicalAllergyLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentMedicalAllergyLogs.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentMedicalAllergyLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentMedicalAllergyLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentMedicalAllergyLogs.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentMedicalAllergyLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




