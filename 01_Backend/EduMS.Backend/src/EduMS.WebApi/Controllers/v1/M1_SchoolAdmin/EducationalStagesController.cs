using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.EducationalStages;
using EduMS.Application.M1_SchoolAdmin.DTOs.EducationalStages;
using EduMS.Application.M1_SchoolAdmin.Queries.EducationalStages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EducationalStagesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.EducationalStages.View)]

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await sender.Send(new GetAllEducationalStagesQuery());
        return Ok(ApiResponse<IEnumerable<EducationalStageDto>>.Success(result));
    }

        [HasPermission(Permissions.EducationalStages.View)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await sender.Send(new GetEducationalStageByIdQuery { Id = id });
        return Ok(ApiResponse<EducationalStageDto>.Success(result));
    }

    [HasPermission(Permissions.EducationalStages.Create)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEducationalStageDto dto)
    {
        var id = await sender.Send(new CreateEducationalStageCommand { Dto = dto });
        return CreatedAtAction(nameof(GetById), new { id }, ApiResponse<long>.Success(id, "Created successfully"));
    }

    [HasPermission(Permissions.EducationalStages.Update)]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateEducationalStageDto dto)
    {
        if (id != dto.Id) return BadRequest(ApiResponse<bool>.Failure("ID mismatch."));
        await sender.Send(new UpdateEducationalStageCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(true, "Updated successfully"));
    }

    [HasPermission(Permissions.EducationalStages.Delete)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await sender.Send(new DeleteEducationalStageCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(true, "Deleted successfully"));
    }
}








