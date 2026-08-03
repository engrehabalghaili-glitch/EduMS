using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.Departments;
using EduMS.Application.M1_SchoolAdmin.DTOs.Departments;
using EduMS.Application.M1_SchoolAdmin.Queries.Departments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class DepartmentsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.Departments.View)]

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await sender.Send(new GetAllDepartmentsQuery());
        return Ok(ApiResponse<IEnumerable<DepartmentDto>>.Success(result));
    }

        [HasPermission(Permissions.Departments.View)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await sender.Send(new GetDepartmentByIdQuery { Id = id });
        return Ok(ApiResponse<DepartmentDto>.Success(result));
    }

    [HasPermission(Permissions.Departments.Create)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDepartmentDto dto)
    {
        var id = await sender.Send(new CreateDepartmentCommand { Dto = dto });
        return CreatedAtAction(nameof(GetById), new { id }, ApiResponse<long>.Success(id, "Created successfully"));
    }

    [HasPermission(Permissions.Departments.Update)]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateDepartmentDto dto)
    {
        if (id != dto.Id) return BadRequest(ApiResponse<bool>.Failure("ID mismatch."));
        await sender.Send(new UpdateDepartmentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(true, "Updated successfully"));
    }

    [HasPermission(Permissions.Departments.Delete)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await sender.Send(new DeleteDepartmentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(true, "Deleted successfully"));
    }
}








