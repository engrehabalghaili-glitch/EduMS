using EduMS.Application.Common.CQRS;
using EduMS.Application.Registrations.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.M2_StudentAffairs;

[ApiController]
[Route("api/v1/student-affairs/registrations")]
public class CreateRegistrationController(IDispatcher dispatcher) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<long>> Create([FromBody] CreateRegistrationCommand command, CancellationToken cancellationToken)
    {
        var result = await dispatcher.SendAsync(command, cancellationToken);
        return Created($"/api/v1/student-affairs/registrations/{result}", result);
    }
}
