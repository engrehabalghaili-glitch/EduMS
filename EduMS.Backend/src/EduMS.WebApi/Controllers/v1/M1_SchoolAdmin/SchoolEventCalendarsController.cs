using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolEventCalendars;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolEventCalendars;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolEventCalendars;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolEventCalendarsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SchoolEventCalendarsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolEventCalendarDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSchoolEventCalendarsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolEventCalendarDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolEventCalendarDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSchoolEventCalendarByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolEventCalendarDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolEventCalendarDto dto)
    {
        var id = await _mediator.Send(new CreateSchoolEventCalendarCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolEventCalendarDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateSchoolEventCalendarCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteSchoolEventCalendarCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}