using EduMS.Application.Common.CQRS;
using EduMS.Application.Registrations.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.M2_StudentAffairs;

[ApiController]
[Route("api/v1/student-affairs/registrations")]
public class UpdateRegistrationController(IDispatcher dispatcher) : ControllerBase
{
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(long id, [FromBody] UpdateRegistrationCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
        {
            return BadRequest("Id in URL does not match Id in the body.");
        }

        var result = await dispatcher.SendAsync(command, cancellationToken);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
