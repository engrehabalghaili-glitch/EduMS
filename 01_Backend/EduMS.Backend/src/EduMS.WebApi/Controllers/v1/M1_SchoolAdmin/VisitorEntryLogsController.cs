using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.VisitorEntryLogs;
using EduMS.Application.M1_SchoolAdmin.DTOs.VisitorEntryLogs;
using EduMS.Application.M1_SchoolAdmin.Queries.VisitorEntryLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class VisitorEntryLogsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<VisitorEntryLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllVisitorEntryLogsQuery());
        return Ok(ApiResponse<IEnumerable<VisitorEntryLogDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<VisitorEntryLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetVisitorEntryLogByIdQuery { Id = id });
        return Ok(ApiResponse<VisitorEntryLogDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateVisitorEntryLogDto dto)
    {
        var id = await sender.Send(new CreateVisitorEntryLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateVisitorEntryLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateVisitorEntryLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteVisitorEntryLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



