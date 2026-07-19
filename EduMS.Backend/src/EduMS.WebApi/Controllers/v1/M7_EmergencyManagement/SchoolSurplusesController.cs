using EduMS.Application.Common.Responses;
using EduMS.Application.M7_EmergencyManagement.Commands.SchoolSurpluses;
using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolSurpluses;
using EduMS.Application.M7_EmergencyManagement.Queries.SchoolSurpluses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M7_EmergencyManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolSurplusesController : ControllerBase
{
    private readonly IMediator _mediator;

    public SchoolSurplusesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolSurplusDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSchoolSurplusesQuery());
        return Ok(ApiResponse<IEnumerable<SchoolSurplusDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolSurplusDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSchoolSurplusByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolSurplusDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolSurplusDto dto)
    {
        var id = await _mediator.Send(new CreateSchoolSurplusCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolSurplusDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateSchoolSurplusCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteSchoolSurplusCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}