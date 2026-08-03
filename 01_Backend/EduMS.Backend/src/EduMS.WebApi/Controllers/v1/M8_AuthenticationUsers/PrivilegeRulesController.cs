using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.PrivilegeRules;
using EduMS.Application.M8_AuthenticationUsers.DTOs.PrivilegeRules;
using EduMS.Application.M8_AuthenticationUsers.Queries.PrivilegeRules;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class PrivilegeRulesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.PrivilegeRules.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<PrivilegeRuleDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllPrivilegeRulesQuery());
        return Ok(ApiResponse<IEnumerable<PrivilegeRuleDto>>.Success(result));
    }

    [HasPermission(Permissions.PrivilegeRules.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<PrivilegeRuleDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetPrivilegeRuleByIdQuery { Id = id });
        return Ok(ApiResponse<PrivilegeRuleDto>.Success(result));
    }

    [HasPermission(Permissions.PrivilegeRules.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreatePrivilegeRuleDto dto)
    {
        var id = await sender.Send(new CreatePrivilegeRuleCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.PrivilegeRules.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdatePrivilegeRuleDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdatePrivilegeRuleCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.PrivilegeRules.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeletePrivilegeRuleCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




