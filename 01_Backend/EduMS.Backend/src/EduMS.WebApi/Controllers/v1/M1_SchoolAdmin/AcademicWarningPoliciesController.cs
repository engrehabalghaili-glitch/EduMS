using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.AcademicWarningPolicies;
using EduMS.Application.M1_SchoolAdmin.DTOs.AcademicWarningPolicies;
using EduMS.Application.M1_SchoolAdmin.Queries.AcademicWarningPolicies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AcademicWarningPoliciesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AcademicWarningPolicyDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAcademicWarningPoliciesQuery());
        return Ok(ApiResponse<IEnumerable<AcademicWarningPolicyDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AcademicWarningPolicyDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAcademicWarningPolicyByIdQuery { Id = id });
        return Ok(ApiResponse<AcademicWarningPolicyDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAcademicWarningPolicyDto dto)
    {
        var id = await sender.Send(new CreateAcademicWarningPolicyCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAcademicWarningPolicyDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAcademicWarningPolicyCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAcademicWarningPolicyCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



