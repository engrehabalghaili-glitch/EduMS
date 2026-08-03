using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.BehavioralLogs;
using EduMS.Application.M2_StudentAffairs.DTOs.BehavioralLogs;
using EduMS.Application.M2_StudentAffairs.Queries.BehavioralLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class BehavioralLogsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.BehavioralLogs.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<BehavioralLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllBehavioralLogsQuery());
        return Ok(ApiResponse<IEnumerable<BehavioralLogDto>>.Success(result));
    }

    [HasPermission(Permissions.BehavioralLogs.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<BehavioralLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetBehavioralLogByIdQuery { Id = id });
        return Ok(ApiResponse<BehavioralLogDto>.Success(result));
    }

    [HasPermission(Permissions.BehavioralLogs.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateBehavioralLogDto dto)
    {
        var id = await sender.Send(new CreateBehavioralLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.BehavioralLogs.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateBehavioralLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateBehavioralLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.BehavioralLogs.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteBehavioralLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




