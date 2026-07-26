using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolLevels;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolLevels;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolLevels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolLevelsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolLevelDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSchoolLevelsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolLevelDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolLevelDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSchoolLevelByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolLevelDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolLevelDto dto)
    {
        var id = await sender.Send(new CreateSchoolLevelCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolLevelDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSchoolLevelCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSchoolLevelCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



