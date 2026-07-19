using EduMS.Application.Common.Responses;
using EduMS.Application.M7_EmergencyManagement.Commands.SchoolAwards;
using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolAwards;
using EduMS.Application.M7_EmergencyManagement.Queries.SchoolAwards;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M7_EmergencyManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolAwardsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SchoolAwardsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolAwardDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSchoolAwardsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolAwardDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolAwardDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSchoolAwardByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolAwardDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolAwardDto dto)
    {
        var id = await _mediator.Send(new CreateSchoolAwardCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolAwardDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateSchoolAwardCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteSchoolAwardCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}