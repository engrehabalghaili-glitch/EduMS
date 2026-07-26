using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands;
using EduMS.Application.M1_SchoolAdmin.DTOs.Schools;
using EduMS.Application.M1_SchoolAdmin.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class SchoolsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolDto>>>> GetSchools(
        [FromQuery] bool onlyActive = true, 
        CancellationToken cancellationToken = default)
    {
        var query = new GetSchoolsQuery(onlyActive);
        var result = await _sender.Send(query, cancellationToken);
        
        return Ok(ApiResponse<IEnumerable<SchoolDto>>.Success(result, "Schools retrieved successfully."));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> CreateSchool(
        [FromBody] CreateSchoolDto schoolDto, 
        CancellationToken cancellationToken = default)
    {
        var command = new CreateSchoolCommand(schoolDto);
        var schoolId = await _sender.Send(command, cancellationToken);
        
        return Ok(ApiResponse<long>.Success(schoolId, "School created successfully."));
    }
}
