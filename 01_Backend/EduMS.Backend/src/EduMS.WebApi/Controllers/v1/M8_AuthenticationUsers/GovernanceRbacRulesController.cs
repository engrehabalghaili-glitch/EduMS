using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
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
public class GovernanceRbacRulesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.GovernanceRbacRules.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<GovernanceRbacRuleDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllGovernanceRbacRulesQuery());
        return Ok(ApiResponse<IEnumerable<GovernanceRbacRuleDto>>.Success(result));
    }

    [HasPermission(Permissions.GovernanceRbacRules.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GovernanceRbacRuleDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetGovernanceRbacRuleByIdQuery { Id = id });
        return Ok(ApiResponse<GovernanceRbacRuleDto>.Success(result));
    }

    [HasPermission(Permissions.GovernanceRbacRules.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateGovernanceRbacRuleDto dto)
    {
        var id = await sender.Send(new CreateGovernanceRbacRuleCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.GovernanceRbacRules.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateGovernanceRbacRuleDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateGovernanceRbacRuleCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.GovernanceRbacRules.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteGovernanceRbacRuleCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




