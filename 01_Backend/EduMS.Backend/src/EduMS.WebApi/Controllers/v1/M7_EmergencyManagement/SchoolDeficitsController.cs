using EduMS.Application.Common.Responses;
using EduMS.Application.M7_EmergencyManagement.Commands.SchoolDeficits;
using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolDeficits;
using EduMS.Application.M7_EmergencyManagement.Queries.SchoolDeficits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M7_EmergencyManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolDeficitsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolDeficitDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSchoolDeficitsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolDeficitDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolDeficitDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSchoolDeficitByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolDeficitDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolDeficitDto dto)
    {
        var id = await sender.Send(new CreateSchoolDeficitCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolDeficitDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSchoolDeficitCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSchoolDeficitCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



