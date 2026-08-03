using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.ClassSchedules;
using EduMS.Application.M1_SchoolAdmin.DTOs.ClassSchedules;
using EduMS.Application.M1_SchoolAdmin.Queries.ClassSchedules;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ClassSchedulesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.ClassSchedules.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ClassScheduleDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllClassSchedulesQuery());
        return Ok(ApiResponse<IEnumerable<ClassScheduleDto>>.Success(result));
    }

        [HasPermission(Permissions.ClassSchedules.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ClassScheduleDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetClassScheduleByIdQuery { Id = id });
        return Ok(ApiResponse<ClassScheduleDto>.Success(result));
    }

    [HasPermission(Permissions.ClassSchedules.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateClassScheduleDto dto)
    {
        var id = await sender.Send(new CreateClassScheduleCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.ClassSchedules.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateClassScheduleDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateClassScheduleCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.ClassSchedules.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteClassScheduleCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







