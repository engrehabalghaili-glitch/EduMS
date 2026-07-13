using EduMS.Application.Common.CQRS;
using EduMS.Application.Schools.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/school-admin/schools")]
public class RegisterSchoolController(IDispatcher dispatcher) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<long>> Register([FromBody] RegisterSchoolCommand command, CancellationToken cancellationToken)
    {
        var result = await dispatcher.SendAsync(command, cancellationToken);
        return Ok(result);
    }
}
