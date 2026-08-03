using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.TeacherSchedules;
using EduMS.Application.M3_EmployeeManagement.DTOs.TeacherSchedules;
using EduMS.Application.M3_EmployeeManagement.Queries.TeacherSchedules;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class TeacherSchedulesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.TeacherSchedules.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<TeacherScheduleDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllTeacherSchedulesQuery());
        return Ok(ApiResponse<IEnumerable<TeacherScheduleDto>>.Success(result));
    }

    [HasPermission(Permissions.TeacherSchedules.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<TeacherScheduleDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetTeacherScheduleByIdQuery { Id = id });
        return Ok(ApiResponse<TeacherScheduleDto>.Success(result));
    }

    [HasPermission(Permissions.TeacherSchedules.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateTeacherScheduleDto dto)
    {
        var id = await sender.Send(new CreateTeacherScheduleCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.TeacherSchedules.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateTeacherScheduleDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateTeacherScheduleCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.TeacherSchedules.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteTeacherScheduleCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




