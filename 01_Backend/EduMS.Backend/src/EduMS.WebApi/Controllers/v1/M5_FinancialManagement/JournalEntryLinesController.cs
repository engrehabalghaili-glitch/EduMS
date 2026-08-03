using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.JournalEntryLines;
using EduMS.Application.M5_FinancialManagement.DTOs.JournalEntryLines;
using EduMS.Application.M5_FinancialManagement.Queries.JournalEntryLines;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class JournalEntryLinesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.JournalEntryLines.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<JournalEntryLineDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllJournalEntryLinesQuery());
        return Ok(ApiResponse<IEnumerable<JournalEntryLineDto>>.Success(result));
    }

    [HasPermission(Permissions.JournalEntryLines.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<JournalEntryLineDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetJournalEntryLineByIdQuery { Id = id });
        return Ok(ApiResponse<JournalEntryLineDto>.Success(result));
    }

    [HasPermission(Permissions.JournalEntryLines.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateJournalEntryLineDto dto)
    {
        var id = await sender.Send(new CreateJournalEntryLineCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.JournalEntryLines.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateJournalEntryLineDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateJournalEntryLineCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.JournalEntryLines.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteJournalEntryLineCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




