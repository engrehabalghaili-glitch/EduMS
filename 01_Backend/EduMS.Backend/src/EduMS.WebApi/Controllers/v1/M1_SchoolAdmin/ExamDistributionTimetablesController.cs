using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.ExamDistributionTimetables;
using EduMS.Application.M1_SchoolAdmin.DTOs.ExamDistributionTimetables;
using EduMS.Application.M1_SchoolAdmin.Queries.ExamDistributionTimetables;
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
public class ExamDistributionTimetablesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.ExamDistributionTimetables.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ExamDistributionTimetableDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllExamDistributionTimetablesQuery());
        return Ok(ApiResponse<IEnumerable<ExamDistributionTimetableDto>>.Success(result));
    }

        [HasPermission(Permissions.ExamDistributionTimetables.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ExamDistributionTimetableDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetExamDistributionTimetableByIdQuery { Id = id });
        return Ok(ApiResponse<ExamDistributionTimetableDto>.Success(result));
    }

    [HasPermission(Permissions.ExamDistributionTimetables.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateExamDistributionTimetableDto dto)
    {
        var id = await sender.Send(new CreateExamDistributionTimetableCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.ExamDistributionTimetables.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateExamDistributionTimetableDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateExamDistributionTimetableCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.ExamDistributionTimetables.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteExamDistributionTimetableCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







