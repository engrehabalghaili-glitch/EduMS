using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentCanteenPurchaseLogs;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentCanteenPurchaseLogs;
using EduMS.Application.M2_StudentAffairs.Queries.StudentCanteenPurchaseLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentCanteenPurchaseLogsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentCanteenPurchaseLogs.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentCanteenPurchaseLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentCanteenPurchaseLogsQuery());
        return Ok(ApiResponse<IEnumerable<StudentCanteenPurchaseLogDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentCanteenPurchaseLogs.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentCanteenPurchaseLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentCanteenPurchaseLogByIdQuery { Id = id });
        return Ok(ApiResponse<StudentCanteenPurchaseLogDto>.Success(result));
    }

    [HasPermission(Permissions.StudentCanteenPurchaseLogs.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentCanteenPurchaseLogDto dto)
    {
        var id = await sender.Send(new CreateStudentCanteenPurchaseLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentCanteenPurchaseLogs.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentCanteenPurchaseLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentCanteenPurchaseLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentCanteenPurchaseLogs.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentCanteenPurchaseLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




