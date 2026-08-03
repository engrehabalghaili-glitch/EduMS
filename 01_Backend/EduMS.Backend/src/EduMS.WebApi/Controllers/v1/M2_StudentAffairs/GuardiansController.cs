using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.Guardians;
using EduMS.Application.M2_StudentAffairs.DTOs.Guardians;
using EduMS.Application.M2_StudentAffairs.Queries.Guardians;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class GuardiansController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.Guardians.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<GuardianDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllGuardiansQuery());
        return Ok(ApiResponse<IEnumerable<GuardianDto>>.Success(result));
    }

    [HasPermission(Permissions.Guardians.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GuardianDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetGuardianByIdQuery { Id = id });
        return Ok(ApiResponse<GuardianDto>.Success(result));
    }

    [HasPermission(Permissions.Guardians.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateGuardianDto dto)
    {
        var id = await sender.Send(new CreateGuardianCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.Guardians.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateGuardianDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateGuardianCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.Guardians.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteGuardianCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




