using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolShifts;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolShifts;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolShifts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolShiftsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SchoolShiftsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolShiftDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSchoolShiftsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolShiftDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolShiftDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSchoolShiftByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolShiftDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolShiftDto dto)
    {
        var id = await _mediator.Send(new CreateSchoolShiftCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolShiftDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateSchoolShiftCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteSchoolShiftCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}