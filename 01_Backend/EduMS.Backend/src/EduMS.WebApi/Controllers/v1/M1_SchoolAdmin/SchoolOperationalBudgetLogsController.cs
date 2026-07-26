using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolOperationalBudgetLogs;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolOperationalBudgetLogs;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolOperationalBudgetLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolOperationalBudgetLogsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolOperationalBudgetLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSchoolOperationalBudgetLogsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolOperationalBudgetLogDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolOperationalBudgetLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSchoolOperationalBudgetLogByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolOperationalBudgetLogDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolOperationalBudgetLogDto dto)
    {
        var id = await sender.Send(new CreateSchoolOperationalBudgetLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolOperationalBudgetLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSchoolOperationalBudgetLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSchoolOperationalBudgetLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



