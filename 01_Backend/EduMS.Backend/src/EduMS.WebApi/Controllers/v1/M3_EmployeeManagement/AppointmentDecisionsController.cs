using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.AppointmentDecisions;
using EduMS.Application.M3_EmployeeManagement.DTOs.AppointmentDecisions;
using EduMS.Application.M3_EmployeeManagement.Queries.AppointmentDecisions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AppointmentDecisionsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AppointmentDecisions.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AppointmentDecisionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAppointmentDecisionsQuery());
        return Ok(ApiResponse<IEnumerable<AppointmentDecisionDto>>.Success(result));
    }

    [HasPermission(Permissions.AppointmentDecisions.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AppointmentDecisionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAppointmentDecisionByIdQuery { Id = id });
        return Ok(ApiResponse<AppointmentDecisionDto>.Success(result));
    }

    [HasPermission(Permissions.AppointmentDecisions.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAppointmentDecisionDto dto)
    {
        var id = await sender.Send(new CreateAppointmentDecisionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AppointmentDecisions.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAppointmentDecisionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAppointmentDecisionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AppointmentDecisions.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAppointmentDecisionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




