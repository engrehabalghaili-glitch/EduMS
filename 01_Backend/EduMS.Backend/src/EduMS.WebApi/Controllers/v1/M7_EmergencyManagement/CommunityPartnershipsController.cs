using EduMS.Application.Common.Responses;
using EduMS.Application.M7_EmergencyManagement.Commands.CommunityPartnerships;
using EduMS.Application.M7_EmergencyManagement.DTOs.CommunityPartnerships;
using EduMS.Application.M7_EmergencyManagement.Queries.CommunityPartnerships;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M7_EmergencyManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class CommunityPartnershipsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<CommunityPartnershipDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllCommunityPartnershipsQuery());
        return Ok(ApiResponse<IEnumerable<CommunityPartnershipDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<CommunityPartnershipDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetCommunityPartnershipByIdQuery { Id = id });
        return Ok(ApiResponse<CommunityPartnershipDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateCommunityPartnershipDto dto)
    {
        var id = await sender.Send(new CreateCommunityPartnershipCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateCommunityPartnershipDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateCommunityPartnershipCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteCommunityPartnershipCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



