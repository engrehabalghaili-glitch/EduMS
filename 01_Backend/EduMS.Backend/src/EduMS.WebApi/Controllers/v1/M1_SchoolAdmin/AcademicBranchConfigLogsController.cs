using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.AcademicBranchConfigLogs;
using EduMS.Application.M1_SchoolAdmin.DTOs.AcademicBranchConfigLogs;
using EduMS.Application.M1_SchoolAdmin.Queries.AcademicBranchConfigLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AcademicBranchConfigLogsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AcademicBranchConfigLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAcademicBranchConfigLogsQuery());
        return Ok(ApiResponse<IEnumerable<AcademicBranchConfigLogDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AcademicBranchConfigLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAcademicBranchConfigLogByIdQuery { Id = id });
        return Ok(ApiResponse<AcademicBranchConfigLogDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAcademicBranchConfigLogDto dto)
    {
        var id = await sender.Send(new CreateAcademicBranchConfigLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAcademicBranchConfigLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAcademicBranchConfigLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAcademicBranchConfigLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



