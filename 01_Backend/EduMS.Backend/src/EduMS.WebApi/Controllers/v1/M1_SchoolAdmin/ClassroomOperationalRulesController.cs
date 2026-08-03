using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.ClassroomOperationalRules;
using EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomOperationalRules;
using EduMS.Application.M1_SchoolAdmin.Queries.ClassroomOperationalRules;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ClassroomOperationalRulesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.ClassroomOperationalRules.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ClassroomOperationalRuleDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllClassroomOperationalRulesQuery());
        return Ok(ApiResponse<IEnumerable<ClassroomOperationalRuleDto>>.Success(result));
    }

        [HasPermission(Permissions.ClassroomOperationalRules.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ClassroomOperationalRuleDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetClassroomOperationalRuleByIdQuery { Id = id });
        return Ok(ApiResponse<ClassroomOperationalRuleDto>.Success(result));
    }

    [HasPermission(Permissions.ClassroomOperationalRules.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateClassroomOperationalRuleDto dto)
    {
        var id = await sender.Send(new CreateClassroomOperationalRuleCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.ClassroomOperationalRules.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateClassroomOperationalRuleDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateClassroomOperationalRuleCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.ClassroomOperationalRules.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteClassroomOperationalRuleCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







