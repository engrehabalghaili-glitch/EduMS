using EduMS.Application.Common.CQRS;
using EduMS.Application.Students.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.M2_StudentAffairs;

[ApiController]
[Route("api/v1/student-affairs/students")]
public class GetStudentEnrollmentSummaryController(IDispatcher dispatcher) : ControllerBase
{
    [HttpGet("{enrollmentNumber}/summary")]
    public async Task<ActionResult<StudentEnrollmentSummaryDto>> GetSummary(string enrollmentNumber, CancellationToken cancellationToken)
    {
        var result = await dispatcher.QueryAsync(new GetStudentEnrollmentSummaryQuery(enrollmentNumber), cancellationToken);
        if (result == null) return NotFound(new { message = $"Student with enrollment number '{enrollmentNumber}' not found." });
        return Ok(result);
    }
}
