using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.GovernanceRbacRules;
using EduMS.Application.M8_AuthenticationUsers.DTOs.GovernanceRbacRules;
using EduMS.Application.M8_AuthenticationUsers.Queries.GovernanceRbacRules;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class GovernanceRbacRulesController : ControllerBase
{
    private readonly IMediator _mediator;

    public GovernanceRbacRulesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<GovernanceRbacRuleDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllGovernanceRbacRulesQuery());
        return Ok(ApiResponse<IEnumerable<GovernanceRbacRuleDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GovernanceRbacRuleDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetGovernanceRbacRuleByIdQuery { Id = id });
        return Ok(ApiResponse<GovernanceRbacRuleDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateGovernanceRbacRuleDto dto)
    {
        var id = await _mediator.Send(new CreateGovernanceRbacRuleCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateGovernanceRbacRuleDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateGovernanceRbacRuleCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteGovernanceRbacRuleCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}