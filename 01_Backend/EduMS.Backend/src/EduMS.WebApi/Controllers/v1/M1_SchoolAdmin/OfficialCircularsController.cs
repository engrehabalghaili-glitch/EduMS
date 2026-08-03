using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.OfficialCirculars;
using EduMS.Application.M1_SchoolAdmin.DTOs.OfficialCirculars;
using EduMS.Application.M1_SchoolAdmin.Queries.OfficialCirculars;
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
public class OfficialCircularsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.OfficialCirculars.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<OfficialCircularDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllOfficialCircularsQuery());
        return Ok(ApiResponse<IEnumerable<OfficialCircularDto>>.Success(result));
    }

        [HasPermission(Permissions.OfficialCirculars.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<OfficialCircularDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetOfficialCircularByIdQuery { Id = id });
        return Ok(ApiResponse<OfficialCircularDto>.Success(result));
    }

    [HasPermission(Permissions.OfficialCirculars.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateOfficialCircularDto dto)
    {
        var id = await sender.Send(new CreateOfficialCircularCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.OfficialCirculars.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateOfficialCircularDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateOfficialCircularCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.OfficialCirculars.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteOfficialCircularCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







