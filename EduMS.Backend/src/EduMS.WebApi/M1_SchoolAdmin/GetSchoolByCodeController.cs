using EduMS.Application.Common.CQRS;
using EduMS.Application.Schools.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/school-admin/schools")]
public class GetSchoolByCodeController(IDispatcher dispatcher) : ControllerBase
{
    [HttpGet("{code}")]
    public async Task<ActionResult<SchoolDetailsDto>> GetByCode(string code, CancellationToken cancellationToken)
    {
        var result = await dispatcher.QueryAsync(new GetSchoolByCodeQuery(code), cancellationToken);
        if (result == null) return NotFound(new { message = $"School with code '{code}' not found." });
        return Ok(result);
    }
}
