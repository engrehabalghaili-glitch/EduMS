using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentComplaintLogs;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentComplaintLogs;
using EduMS.Application.M2_StudentAffairs.Queries.StudentComplaintLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentComplaintLogsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentComplaintLogs.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentComplaintLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentComplaintLogsQuery());
        return Ok(ApiResponse<IEnumerable<StudentComplaintLogDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentComplaintLogs.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentComplaintLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentComplaintLogByIdQuery { Id = id });
        return Ok(ApiResponse<StudentComplaintLogDto>.Success(result));
    }

    [HasPermission(Permissions.StudentComplaintLogs.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentComplaintLogDto dto)
    {
        var id = await sender.Send(new CreateStudentComplaintLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentComplaintLogs.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentComplaintLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentComplaintLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentComplaintLogs.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentComplaintLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




