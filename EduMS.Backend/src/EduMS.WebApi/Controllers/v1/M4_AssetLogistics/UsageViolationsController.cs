using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.UsageViolations;
using EduMS.Application.M4_AssetLogistics.DTOs.UsageViolations;
using EduMS.Application.M4_AssetLogistics.Queries.UsageViolations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class UsageViolationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsageViolationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<UsageViolationDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllUsageViolationsQuery());
        return Ok(ApiResponse<IEnumerable<UsageViolationDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<UsageViolationDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetUsageViolationByIdQuery { Id = id });
        return Ok(ApiResponse<UsageViolationDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateUsageViolationDto dto)
    {
        var id = await _mediator.Send(new CreateUsageViolationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateUsageViolationDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateUsageViolationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteUsageViolationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}