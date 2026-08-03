using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolContactInfos;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolContactInfos;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolContactInfos;
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
public class SchoolContactInfosController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.SchoolContactInfos.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolContactInfoDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSchoolContactInfosQuery());
        return Ok(ApiResponse<IEnumerable<SchoolContactInfoDto>>.Success(result));
    }

        [HasPermission(Permissions.SchoolContactInfos.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolContactInfoDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSchoolContactInfoByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolContactInfoDto>.Success(result));
    }

    [HasPermission(Permissions.SchoolContactInfos.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolContactInfoDto dto)
    {
        var id = await sender.Send(new CreateSchoolContactInfoCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.SchoolContactInfos.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolContactInfoDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSchoolContactInfoCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.SchoolContactInfos.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSchoolContactInfoCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







