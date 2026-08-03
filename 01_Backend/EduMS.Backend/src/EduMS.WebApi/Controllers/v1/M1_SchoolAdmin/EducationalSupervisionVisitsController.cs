using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.EducationalSupervisionVisits;
using EduMS.Application.M1_SchoolAdmin.DTOs.EducationalSupervisionVisits;
using EduMS.Application.M1_SchoolAdmin.Queries.EducationalSupervisionVisits;
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
public class EducationalSupervisionVisitsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.EducationalSupervisionVisits.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EducationalSupervisionVisitDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEducationalSupervisionVisitsQuery());
        return Ok(ApiResponse<IEnumerable<EducationalSupervisionVisitDto>>.Success(result));
    }

        [HasPermission(Permissions.EducationalSupervisionVisits.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EducationalSupervisionVisitDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEducationalSupervisionVisitByIdQuery { Id = id });
        return Ok(ApiResponse<EducationalSupervisionVisitDto>.Success(result));
    }

    [HasPermission(Permissions.EducationalSupervisionVisits.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEducationalSupervisionVisitDto dto)
    {
        var id = await sender.Send(new CreateEducationalSupervisionVisitCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.EducationalSupervisionVisits.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEducationalSupervisionVisitDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEducationalSupervisionVisitCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.EducationalSupervisionVisits.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEducationalSupervisionVisitCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







