using EduMS.Application.Common.Responses;
using EduMS.Application.M7_EmergencyManagement.Commands.RemediationPlans;
using EduMS.Application.M7_EmergencyManagement.DTOs.RemediationPlans;
using EduMS.Application.M7_EmergencyManagement.Queries.RemediationPlans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M7_EmergencyManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class RemediationPlansController : ControllerBase
{
    private readonly IMediator _mediator;

    public RemediationPlansController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<RemediationPlanDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllRemediationPlansQuery());
        return Ok(ApiResponse<IEnumerable<RemediationPlanDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<RemediationPlanDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetRemediationPlanByIdQuery { Id = id });
        return Ok(ApiResponse<RemediationPlanDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateRemediationPlanDto dto)
    {
        var id = await _mediator.Send(new CreateRemediationPlanCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateRemediationPlanDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateRemediationPlanCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteRemediationPlanCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}