using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.AcademicLockPeriods;
using EduMS.Application.M1_SchoolAdmin.DTOs.AcademicLockPeriods;
using EduMS.Application.M1_SchoolAdmin.Queries.AcademicLockPeriods;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AcademicLockPeriodsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AcademicLockPeriodsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AcademicLockPeriodDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAcademicLockPeriodsQuery());
        return Ok(ApiResponse<IEnumerable<AcademicLockPeriodDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AcademicLockPeriodDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAcademicLockPeriodByIdQuery { Id = id });
        return Ok(ApiResponse<AcademicLockPeriodDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAcademicLockPeriodDto dto)
    {
        var id = await _mediator.Send(new CreateAcademicLockPeriodCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAcademicLockPeriodDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAcademicLockPeriodCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAcademicLockPeriodCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}