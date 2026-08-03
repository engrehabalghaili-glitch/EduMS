using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentHealthRecords;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentHealthRecords;
using EduMS.Application.M2_StudentAffairs.Queries.StudentHealthRecords;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentHealthRecordsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentHealthRecords.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentHealthRecordDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentHealthRecordsQuery());
        return Ok(ApiResponse<IEnumerable<StudentHealthRecordDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentHealthRecords.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentHealthRecordDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentHealthRecordByIdQuery { Id = id });
        return Ok(ApiResponse<StudentHealthRecordDto>.Success(result));
    }

    [HasPermission(Permissions.StudentHealthRecords.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentHealthRecordDto dto)
    {
        var id = await sender.Send(new CreateStudentHealthRecordCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentHealthRecords.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentHealthRecordDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentHealthRecordCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentHealthRecords.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentHealthRecordCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




