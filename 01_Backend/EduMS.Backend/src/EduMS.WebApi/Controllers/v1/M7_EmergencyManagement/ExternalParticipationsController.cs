using EduMS.Application.Common.Responses;
using EduMS.Application.M7_EmergencyManagement.Commands.ExternalParticipations;
using EduMS.Application.M7_EmergencyManagement.DTOs.ExternalParticipations;
using EduMS.Application.M7_EmergencyManagement.Queries.ExternalParticipations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M7_EmergencyManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ExternalParticipationsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ExternalParticipationDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllExternalParticipationsQuery());
        return Ok(ApiResponse<IEnumerable<ExternalParticipationDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ExternalParticipationDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetExternalParticipationByIdQuery { Id = id });
        return Ok(ApiResponse<ExternalParticipationDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateExternalParticipationDto dto)
    {
        var id = await sender.Send(new CreateExternalParticipationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateExternalParticipationDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateExternalParticipationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteExternalParticipationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



