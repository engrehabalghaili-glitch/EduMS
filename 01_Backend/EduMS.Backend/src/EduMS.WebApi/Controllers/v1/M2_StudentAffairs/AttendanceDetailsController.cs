using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.AttendanceDetails;
using EduMS.Application.M2_StudentAffairs.DTOs.AttendanceDetails;
using EduMS.Application.M2_StudentAffairs.Queries.AttendanceDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AttendanceDetailsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AttendanceDetailDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAttendanceDetailsQuery());
        return Ok(ApiResponse<IEnumerable<AttendanceDetailDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AttendanceDetailDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAttendanceDetailByIdQuery { Id = id });
        return Ok(ApiResponse<AttendanceDetailDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAttendanceDetailDto dto)
    {
        var id = await sender.Send(new CreateAttendanceDetailCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAttendanceDetailDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAttendanceDetailCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAttendanceDetailCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



