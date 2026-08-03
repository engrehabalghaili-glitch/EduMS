using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentTransportPreferences;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentTransportPreferences;
using EduMS.Application.M2_StudentAffairs.Queries.StudentTransportPreferences;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentTransportPreferencesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentTransportPreferences.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentTransportPreferenceDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentTransportPreferencesQuery());
        return Ok(ApiResponse<IEnumerable<StudentTransportPreferenceDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentTransportPreferences.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentTransportPreferenceDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentTransportPreferenceByIdQuery { Id = id });
        return Ok(ApiResponse<StudentTransportPreferenceDto>.Success(result));
    }

    [HasPermission(Permissions.StudentTransportPreferences.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentTransportPreferenceDto dto)
    {
        var id = await sender.Send(new CreateStudentTransportPreferenceCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentTransportPreferences.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentTransportPreferenceDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentTransportPreferenceCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentTransportPreferences.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentTransportPreferenceCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




