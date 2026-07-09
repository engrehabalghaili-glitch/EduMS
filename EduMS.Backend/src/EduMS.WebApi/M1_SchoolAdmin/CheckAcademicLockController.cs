using EduMS.Application.Common.CQRS;
using EduMS.Application.Locks.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/school-admin/academic-lock")]
public class CheckAcademicLockController(IDispatcher dispatcher) : ControllerBase
{
    [HttpGet("check")]
    public async Task<ActionResult<bool>> Check([FromQuery] long schoolId, [FromQuery] DateTime targetDate, CancellationToken cancellationToken)
    {
        var query = new CheckAcademicLockQuery(schoolId, targetDate);
        var result = await dispatcher.QueryAsync(query, cancellationToken);
        return Ok(result);
    }
}
