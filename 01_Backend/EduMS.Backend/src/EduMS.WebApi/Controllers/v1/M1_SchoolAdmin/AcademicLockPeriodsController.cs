using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.AcademicLockPeriods;
using EduMS.Application.M1_SchoolAdmin.DTOs.AcademicLockPeriods;
using EduMS.Application.M1_SchoolAdmin.Queries.AcademicLockPeriods;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AcademicLockPeriodsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AcademicLockPeriods.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AcademicLockPeriodDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAcademicLockPeriodsQuery());
        return Ok(ApiResponse<IEnumerable<AcademicLockPeriodDto>>.Success(result));
    }

        [HasPermission(Permissions.AcademicLockPeriods.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AcademicLockPeriodDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAcademicLockPeriodByIdQuery { Id = id });
        return Ok(ApiResponse<AcademicLockPeriodDto>.Success(result));
    }

    [HasPermission(Permissions.AcademicLockPeriods.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAcademicLockPeriodDto dto)
    {
        var id = await sender.Send(new CreateAcademicLockPeriodCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AcademicLockPeriods.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAcademicLockPeriodDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAcademicLockPeriodCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AcademicLockPeriods.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAcademicLockPeriodCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







