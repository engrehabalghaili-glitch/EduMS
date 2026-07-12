using EduMS.Application.Common.CQRS;
using EduMS.Application.Registrations.DTOs;
using EduMS.Application.Registrations.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.M2_StudentAffairs;

[ApiController]
[Route("api/v1/student-affairs/registrations")]
public class GetRegistrationByIdController(IDispatcher dispatcher) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<RegistrationDto>> GetById(long id, CancellationToken cancellationToken)
    {
        var result = await dispatcher.QueryAsync(new GetRegistrationByIdQuery(id), cancellationToken);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
