using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.DetailedAcademicWarningLogs;
using EduMS.Application.M2_StudentAffairs.DTOs.DetailedAcademicWarningLogs;
using EduMS.Application.M2_StudentAffairs.Queries.DetailedAcademicWarningLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class DetailedAcademicWarningLogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DetailedAcademicWarningLogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<DetailedAcademicWarningLogDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllDetailedAcademicWarningLogsQuery());
        return Ok(ApiResponse<IEnumerable<DetailedAcademicWarningLogDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<DetailedAcademicWarningLogDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetDetailedAcademicWarningLogByIdQuery { Id = id });
        return Ok(ApiResponse<DetailedAcademicWarningLogDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateDetailedAcademicWarningLogDto dto)
    {
        var id = await _mediator.Send(new CreateDetailedAcademicWarningLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateDetailedAcademicWarningLogDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateDetailedAcademicWarningLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteDetailedAcademicWarningLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}