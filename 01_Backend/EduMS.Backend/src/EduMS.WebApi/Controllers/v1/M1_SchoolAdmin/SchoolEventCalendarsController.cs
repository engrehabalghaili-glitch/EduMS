using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolEventCalendars;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolEventCalendars;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolEventCalendars;
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
public class SchoolEventCalendarsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.SchoolEventCalendars.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolEventCalendarDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSchoolEventCalendarsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolEventCalendarDto>>.Success(result));
    }

        [HasPermission(Permissions.SchoolEventCalendars.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolEventCalendarDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSchoolEventCalendarByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolEventCalendarDto>.Success(result));
    }

    [HasPermission(Permissions.SchoolEventCalendars.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolEventCalendarDto dto)
    {
        var id = await sender.Send(new CreateSchoolEventCalendarCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.SchoolEventCalendars.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolEventCalendarDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSchoolEventCalendarCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.SchoolEventCalendars.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSchoolEventCalendarCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







