using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.GradeCapacities;
using EduMS.Application.M1_SchoolAdmin.DTOs.GradeCapacities;
using EduMS.Application.M1_SchoolAdmin.Queries.GradeCapacities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class GradeCapacitiesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<GradeCapacityDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllGradeCapacitiesQuery());
        return Ok(ApiResponse<IEnumerable<GradeCapacityDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GradeCapacityDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetGradeCapacityByIdQuery { Id = id });
        return Ok(ApiResponse<GradeCapacityDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateGradeCapacityDto dto)
    {
        var id = await sender.Send(new CreateGradeCapacityCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateGradeCapacityDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateGradeCapacityCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteGradeCapacityCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



