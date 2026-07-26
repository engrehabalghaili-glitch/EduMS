using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolFacilities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolFacilities;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolFacilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolFacilitiesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolFacilityDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSchoolFacilitiesQuery());
        return Ok(ApiResponse<IEnumerable<SchoolFacilityDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolFacilityDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSchoolFacilityByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolFacilityDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolFacilityDto dto)
    {
        var id = await sender.Send(new CreateSchoolFacilityCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolFacilityDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSchoolFacilityCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSchoolFacilityCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



