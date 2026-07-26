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

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<GuardianDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllGuardiansQuery());
        return Ok(ApiResponse<IEnumerable<GuardianDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GuardianDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetGuardianByIdQuery { Id = id });
        return Ok(ApiResponse<GuardianDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateGuardianDto dto)
    {
        var id = await sender.Send(new CreateGuardianCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateGuardianDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateGuardianCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteGuardianCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



