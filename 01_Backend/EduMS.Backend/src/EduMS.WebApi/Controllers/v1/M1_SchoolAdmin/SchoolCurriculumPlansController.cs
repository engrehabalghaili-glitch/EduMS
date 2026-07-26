using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolCurriculumPlans;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCurriculumPlans;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolCurriculumPlans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolCurriculumPlansController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolCurriculumPlanDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSchoolCurriculumPlansQuery());
        return Ok(ApiResponse<IEnumerable<SchoolCurriculumPlanDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolCurriculumPlanDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSchoolCurriculumPlanByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolCurriculumPlanDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolCurriculumPlanDto dto)
    {
        var id = await sender.Send(new CreateSchoolCurriculumPlanCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolCurriculumPlanDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSchoolCurriculumPlanCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSchoolCurriculumPlanCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



