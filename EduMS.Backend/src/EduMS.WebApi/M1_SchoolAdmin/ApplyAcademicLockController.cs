using EduMS.Application.Common.CQRS;
using EduMS.Application.Locks.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/school-admin/academic-lock")]
public class ApplyAcademicLockController(IDispatcher dispatcher) : ControllerBase
{
    [HttpPost("apply")]
    public async Task<ActionResult<long>> Apply([FromBody] ApplyAcademicLockCommand command, CancellationToken cancellationToken)
    {
        var result = await dispatcher.SendAsync(command, cancellationToken);
        return Ok(result);
    }
}
