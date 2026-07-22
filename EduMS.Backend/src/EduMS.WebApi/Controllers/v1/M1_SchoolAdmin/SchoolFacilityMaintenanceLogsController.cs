using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolFacilityMaintenanceLogs;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolFacilityMaintenanceLogs;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolFacilityMaintenanceLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolFacilityMaintenanceLogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SchoolFacilityMaintenanceLogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolFacilityMaintenanceLogDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSchoolFacilityMaintenanceLogsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolFacilityMaintenanceLogDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolFacilityMaintenanceLogDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSchoolFacilityMaintenanceLogByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolFacilityMaintenanceLogDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolFacilityMaintenanceLogDto dto)
    {
        var id = await _mediator.Send(new CreateSchoolFacilityMaintenanceLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolFacilityMaintenanceLogDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateSchoolFacilityMaintenanceLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteSchoolFacilityMaintenanceLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}