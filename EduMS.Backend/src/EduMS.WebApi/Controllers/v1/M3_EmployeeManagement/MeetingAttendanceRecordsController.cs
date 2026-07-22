using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.MeetingAttendanceRecords;
using EduMS.Application.M3_EmployeeManagement.DTOs.MeetingAttendanceRecords;
using EduMS.Application.M3_EmployeeManagement.Queries.MeetingAttendanceRecords;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class MeetingAttendanceRecordsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MeetingAttendanceRecordsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<MeetingAttendanceRecordDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllMeetingAttendanceRecordsQuery());
        return Ok(ApiResponse<IEnumerable<MeetingAttendanceRecordDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<MeetingAttendanceRecordDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetMeetingAttendanceRecordByIdQuery { Id = id });
        return Ok(ApiResponse<MeetingAttendanceRecordDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateMeetingAttendanceRecordDto dto)
    {
        var id = await _mediator.Send(new CreateMeetingAttendanceRecordCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateMeetingAttendanceRecordDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateMeetingAttendanceRecordCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteMeetingAttendanceRecordCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}