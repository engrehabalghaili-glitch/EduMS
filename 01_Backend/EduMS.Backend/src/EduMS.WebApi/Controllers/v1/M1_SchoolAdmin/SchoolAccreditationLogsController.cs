using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolAccreditationLogs;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAccreditationLogs;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolAccreditationLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolAccreditationLogsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolAccreditationLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSchoolAccreditationLogsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolAccreditationLogDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolAccreditationLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSchoolAccreditationLogByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolAccreditationLogDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolAccreditationLogDto dto)
    {
        var id = await sender.Send(new CreateSchoolAccreditationLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolAccreditationLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSchoolAccreditationLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSchoolAccreditationLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



