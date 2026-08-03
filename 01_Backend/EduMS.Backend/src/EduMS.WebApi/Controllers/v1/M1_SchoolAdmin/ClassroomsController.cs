using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.Classrooms;
using EduMS.Application.M1_SchoolAdmin.DTOs.Classrooms;
using EduMS.Application.M1_SchoolAdmin.Queries.Classrooms;
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
public class ClassroomsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.Classrooms.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ClassroomDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllClassroomsQuery());
        return Ok(ApiResponse<IEnumerable<ClassroomDto>>.Success(result));
    }

        [HasPermission(Permissions.Classrooms.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ClassroomDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetClassroomByIdQuery { Id = id });
        return Ok(ApiResponse<ClassroomDto>.Success(result));
    }

    [HasPermission(Permissions.Classrooms.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateClassroomDto dto)
    {
        var id = await sender.Send(new CreateClassroomCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.Classrooms.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateClassroomDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateClassroomCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.Classrooms.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteClassroomCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







