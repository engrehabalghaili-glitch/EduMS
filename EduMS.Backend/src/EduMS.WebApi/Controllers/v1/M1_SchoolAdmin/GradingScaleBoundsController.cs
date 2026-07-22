using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.GradingScaleBounds;
using EduMS.Application.M1_SchoolAdmin.DTOs.GradingScaleBounds;
using EduMS.Application.M1_SchoolAdmin.Queries.GradingScaleBounds;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class GradingScaleBoundsController : ControllerBase
{
    private readonly IMediator _mediator;

    public GradingScaleBoundsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<GradingScaleBoundDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllGradingScaleBoundsQuery());
        return Ok(ApiResponse<IEnumerable<GradingScaleBoundDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GradingScaleBoundDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetGradingScaleBoundByIdQuery { Id = id });
        return Ok(ApiResponse<GradingScaleBoundDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateGradingScaleBoundDto dto)
    {
        var id = await _mediator.Send(new CreateGradingScaleBoundCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateGradingScaleBoundDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateGradingScaleBoundCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteGradingScaleBoundCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}