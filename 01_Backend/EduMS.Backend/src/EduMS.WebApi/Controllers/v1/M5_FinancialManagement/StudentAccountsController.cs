using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.StudentAccounts;
using EduMS.Application.M5_FinancialManagement.DTOs.StudentAccounts;
using EduMS.Application.M5_FinancialManagement.Queries.StudentAccounts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentAccountsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentAccounts.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentAccountDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentAccountsQuery());
        return Ok(ApiResponse<IEnumerable<StudentAccountDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentAccounts.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentAccountDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentAccountByIdQuery { Id = id });
        return Ok(ApiResponse<StudentAccountDto>.Success(result));
    }

    [HasPermission(Permissions.StudentAccounts.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentAccountDto dto)
    {
        var id = await sender.Send(new CreateStudentAccountCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentAccounts.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentAccountDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentAccountCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentAccounts.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentAccountCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




