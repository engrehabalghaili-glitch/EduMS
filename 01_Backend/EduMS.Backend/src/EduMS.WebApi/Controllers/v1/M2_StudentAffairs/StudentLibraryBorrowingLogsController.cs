using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentLibraryBorrowingLogs;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentLibraryBorrowingLogs;
using EduMS.Application.M2_StudentAffairs.Queries.StudentLibraryBorrowingLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentLibraryBorrowingLogsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentLibraryBorrowingLogs.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentLibraryBorrowingLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentLibraryBorrowingLogsQuery());
        return Ok(ApiResponse<IEnumerable<StudentLibraryBorrowingLogDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentLibraryBorrowingLogs.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentLibraryBorrowingLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentLibraryBorrowingLogByIdQuery { Id = id });
        return Ok(ApiResponse<StudentLibraryBorrowingLogDto>.Success(result));
    }

    [HasPermission(Permissions.StudentLibraryBorrowingLogs.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentLibraryBorrowingLogDto dto)
    {
        var id = await sender.Send(new CreateStudentLibraryBorrowingLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentLibraryBorrowingLogs.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentLibraryBorrowingLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentLibraryBorrowingLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentLibraryBorrowingLogs.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentLibraryBorrowingLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




