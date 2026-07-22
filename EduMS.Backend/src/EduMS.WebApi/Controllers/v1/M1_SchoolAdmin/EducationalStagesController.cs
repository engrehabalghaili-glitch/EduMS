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
public class EducationalStagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EducationalStagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllEducationalStagesQuery());
        return Ok(ApiResponse<IEnumerable<EducationalStageDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _mediator.Send(new GetEducationalStageByIdQuery { Id = id });
        return Ok(ApiResponse<EducationalStageDto>.Success(result));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEducationalStageDto dto)
    {
        var id = await _mediator.Send(new CreateEducationalStageCommand { Dto = dto });
        return CreatedAtAction(nameof(GetById), new { id }, ApiResponse<long>.Success(id, "Created successfully"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateEducationalStageDto dto)
    {
        if (id != dto.Id) return BadRequest(ApiResponse<bool>.Failure("ID mismatch."));
        await _mediator.Send(new UpdateEducationalStageCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(true, "Updated successfully"));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _mediator.Send(new DeleteEducationalStageCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(true, "Deleted successfully"));
    }
}