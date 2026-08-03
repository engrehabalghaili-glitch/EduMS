using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.GradingScaleBounds;
using EduMS.Application.M1_SchoolAdmin.DTOs.GradingScaleBounds;
using EduMS.Application.M1_SchoolAdmin.Queries.GradingScaleBounds;
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
public class GradingScaleBoundsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.GradingScaleBounds.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<GradingScaleBoundDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllGradingScaleBoundsQuery());
        return Ok(ApiResponse<IEnumerable<GradingScaleBoundDto>>.Success(result));
    }

        [HasPermission(Permissions.GradingScaleBounds.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GradingScaleBoundDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetGradingScaleBoundByIdQuery { Id = id });
        return Ok(ApiResponse<GradingScaleBoundDto>.Success(result));
    }

    [HasPermission(Permissions.GradingScaleBounds.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateGradingScaleBoundDto dto)
    {
        var id = await sender.Send(new CreateGradingScaleBoundCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.GradingScaleBounds.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateGradingScaleBoundDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateGradingScaleBoundCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.GradingScaleBounds.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteGradingScaleBoundCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







