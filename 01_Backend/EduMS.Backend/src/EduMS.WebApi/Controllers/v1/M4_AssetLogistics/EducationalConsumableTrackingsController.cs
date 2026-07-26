using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.EducationalConsumableTrackings;
using EduMS.Application.M4_AssetLogistics.DTOs.EducationalConsumableTrackings;
using EduMS.Application.M4_AssetLogistics.Queries.EducationalConsumableTrackings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EducationalConsumableTrackingsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EducationalConsumableTrackingDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEducationalConsumableTrackingsQuery());
        return Ok(ApiResponse<IEnumerable<EducationalConsumableTrackingDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EducationalConsumableTrackingDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEducationalConsumableTrackingByIdQuery { Id = id });
        return Ok(ApiResponse<EducationalConsumableTrackingDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEducationalConsumableTrackingDto dto)
    {
        var id = await sender.Send(new CreateEducationalConsumableTrackingCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEducationalConsumableTrackingDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEducationalConsumableTrackingCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEducationalConsumableTrackingCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



