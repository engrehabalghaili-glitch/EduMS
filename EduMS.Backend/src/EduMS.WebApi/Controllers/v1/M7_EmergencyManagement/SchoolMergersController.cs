using EduMS.Application.Common.Responses;
using EduMS.Application.M7_EmergencyManagement.Commands.SchoolMergers;
using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolMergers;
using EduMS.Application.M7_EmergencyManagement.Queries.SchoolMergers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M7_EmergencyManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolMergersController : ControllerBase
{
    private readonly IMediator _mediator;

    public SchoolMergersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolMergerDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSchoolMergersQuery());
        return Ok(ApiResponse<IEnumerable<SchoolMergerDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolMergerDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSchoolMergerByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolMergerDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolMergerDto dto)
    {
        var id = await _mediator.Send(new CreateSchoolMergerCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolMergerDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateSchoolMergerCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteSchoolMergerCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}