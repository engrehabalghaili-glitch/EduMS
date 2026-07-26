using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.Directorates;
using EduMS.Application.M1_SchoolAdmin.DTOs.Directorates;
using EduMS.Application.M1_SchoolAdmin.Queries.Directorates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class DirectoratesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await sender.Send(new GetAllDirectoratesQuery());
        return Ok(ApiResponse<IEnumerable<DirectorateDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await sender.Send(new GetDirectorateByIdQuery { Id = id });
        return Ok(ApiResponse<DirectorateDto>.Success(result));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDirectorateDto dto)
    {
        var id = await sender.Send(new CreateDirectorateCommand { Dto = dto });
        return CreatedAtAction(nameof(GetById), new { id }, ApiResponse<long>.Success(id, "Created successfully"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateDirectorateDto dto)
    {
        if (id != dto.Id) return BadRequest(ApiResponse<bool>.Failure("ID mismatch."));
        await sender.Send(new UpdateDirectorateCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(true, "Updated successfully"));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await sender.Send(new DeleteDirectorateCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(true, "Deleted successfully"));
    }
}



