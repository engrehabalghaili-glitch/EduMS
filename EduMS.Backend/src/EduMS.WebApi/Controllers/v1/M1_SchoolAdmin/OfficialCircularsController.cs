using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.OfficialCirculars;
using EduMS.Application.M1_SchoolAdmin.DTOs.OfficialCirculars;
using EduMS.Application.M1_SchoolAdmin.Queries.OfficialCirculars;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class OfficialCircularsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OfficialCircularsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<OfficialCircularDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllOfficialCircularsQuery());
        return Ok(ApiResponse<IEnumerable<OfficialCircularDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<OfficialCircularDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetOfficialCircularByIdQuery { Id = id });
        return Ok(ApiResponse<OfficialCircularDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateOfficialCircularDto dto)
    {
        var id = await _mediator.Send(new CreateOfficialCircularCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateOfficialCircularDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateOfficialCircularCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteOfficialCircularCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}