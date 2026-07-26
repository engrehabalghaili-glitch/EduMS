using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.JournalEntries;
using EduMS.Application.M5_FinancialManagement.DTOs.JournalEntries;
using EduMS.Application.M5_FinancialManagement.Queries.JournalEntries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class JournalEntriesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<JournalEntryDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllJournalEntriesQuery());
        return Ok(ApiResponse<IEnumerable<JournalEntryDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<JournalEntryDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetJournalEntryByIdQuery { Id = id });
        return Ok(ApiResponse<JournalEntryDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateJournalEntryDto dto)
    {
        var id = await sender.Send(new CreateJournalEntryCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateJournalEntryDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateJournalEntryCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteJournalEntryCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



