using EduMS.Application.Common.CQRS;
using EduMS.Application.Persons.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.M2_StudentAffairs;

[ApiController]
[Route("api/v1/student-affairs/persons")]
public class CreatePersonController(IDispatcher dispatcher) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<long>> Create([FromBody] CreatePersonCommand command, CancellationToken cancellationToken)
    {
        var result = await dispatcher.SendAsync(command, cancellationToken);
        return CreatedAtAction(nameof(Create), new { id = result }, result);
    }
}
