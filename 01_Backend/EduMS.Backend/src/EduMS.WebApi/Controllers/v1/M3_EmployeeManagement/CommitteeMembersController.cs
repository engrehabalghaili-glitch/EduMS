using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.CommitteeMembers;
using EduMS.Application.M3_EmployeeManagement.DTOs.CommitteeMembers;
using EduMS.Application.M3_EmployeeManagement.Queries.CommitteeMembers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class CommitteeMembersController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<CommitteeMemberDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllCommitteeMembersQuery());
        return Ok(ApiResponse<IEnumerable<CommitteeMemberDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<CommitteeMemberDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetCommitteeMemberByIdQuery { Id = id });
        return Ok(ApiResponse<CommitteeMemberDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateCommitteeMemberDto dto)
    {
        var id = await sender.Send(new CreateCommitteeMemberCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateCommitteeMemberDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateCommitteeMemberCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteCommitteeMemberCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



