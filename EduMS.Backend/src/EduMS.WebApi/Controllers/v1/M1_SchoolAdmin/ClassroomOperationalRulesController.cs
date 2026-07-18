using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.ClassroomOperationalRules;
using EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomOperationalRules;
using EduMS.Application.M1_SchoolAdmin.Queries.ClassroomOperationalRules;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ClassroomOperationalRulesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClassroomOperationalRulesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ClassroomOperationalRuleDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllClassroomOperationalRulesQuery());
        return Ok(ApiResponse<IEnumerable<ClassroomOperationalRuleDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ClassroomOperationalRuleDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetClassroomOperationalRuleByIdQuery { Id = id });
        return Ok(ApiResponse<ClassroomOperationalRuleDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateClassroomOperationalRuleDto dto)
    {
        var id = await _mediator.Send(new CreateClassroomOperationalRuleCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateClassroomOperationalRuleDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateClassroomOperationalRuleCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteClassroomOperationalRuleCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}