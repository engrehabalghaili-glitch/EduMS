using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolAcademicYears;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAcademicYears;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolAcademicYears;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolAcademicYearsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.SchoolAcademicYears.View)]

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await sender.Send(new GetAllSchoolAcademicYearsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolAcademicYearDto>>.Success(result));
    }

        [HasPermission(Permissions.SchoolAcademicYears.View)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await sender.Send(new GetSchoolAcademicYearByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolAcademicYearDto>.Success(result));
    }

    [HasPermission(Permissions.SchoolAcademicYears.Create)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSchoolAcademicYearDto dto)
    {
        var id = await sender.Send(new CreateSchoolAcademicYearCommand { Dto = dto });
        return CreatedAtAction(nameof(GetById), new { id }, ApiResponse<long>.Success(id, "Created successfully"));
    }

    [HasPermission(Permissions.SchoolAcademicYears.Update)]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateSchoolAcademicYearDto dto)
    {
        if (id != dto.Id) return BadRequest(ApiResponse<bool>.Failure("ID mismatch."));
        await sender.Send(new UpdateSchoolAcademicYearCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(true, "Updated successfully"));
    }

    [HasPermission(Permissions.SchoolAcademicYears.Delete)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await sender.Send(new DeleteSchoolAcademicYearCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(true, "Deleted successfully"));
    }
}








