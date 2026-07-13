using EduMS.Application.Common.CQRS;
using EduMS.Application.Students.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.M2_StudentAffairs;

[ApiController]
[Route("api/v1/student-affairs/students")]
public class EnrollStudentController(IDispatcher dispatcher) : ControllerBase
{
    [HttpPost("enroll")]
    public async Task<ActionResult<long>> Enroll([FromBody] EnrollStudentCommand command, CancellationToken cancellationToken)
    {
        var result = await dispatcher.SendAsync(command, cancellationToken);
        return Ok(result);
    }
}
