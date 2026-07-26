using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentTransferLogs;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentTransferLogs;
using EduMS.Application.M2_StudentAffairs.Queries.StudentTransferLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentTransferLogsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentTransferLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentTransferLogsQuery());
        return Ok(ApiResponse<IEnumerable<StudentTransferLogDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentTransferLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentTransferLogByIdQuery { Id = id });
        return Ok(ApiResponse<StudentTransferLogDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentTransferLogDto dto)
    {
        var id = await sender.Send(new CreateStudentTransferLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentTransferLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentTransferLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentTransferLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



