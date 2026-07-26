using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolSemesters;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolSemesters;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolSemesters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolSemestersController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await sender.Send(new GetAllSchoolSemestersQuery());
        return Ok(ApiResponse<IEnumerable<SchoolSemesterDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await sender.Send(new GetSchoolSemesterByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolSemesterDto>.Success(result));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSchoolSemesterDto dto)
    {
        var id = await sender.Send(new CreateSchoolSemesterCommand { Dto = dto });
        return CreatedAtAction(nameof(GetById), new { id }, ApiResponse<long>.Success(id, "Created successfully"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateSchoolSemesterDto dto)
    {
        if (id != dto.Id) return BadRequest(ApiResponse<bool>.Failure("ID mismatch."));
        await sender.Send(new UpdateSchoolSemesterCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(true, "Updated successfully"));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await sender.Send(new DeleteSchoolSemesterCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(true, "Deleted successfully"));
    }
}



