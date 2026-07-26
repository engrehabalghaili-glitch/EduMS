using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.AccessPolicies;
using EduMS.Application.M8_AuthenticationUsers.DTOs.AccessPolicies;
using EduMS.Application.M8_AuthenticationUsers.Queries.AccessPolicies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AccessPoliciesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AccessPolicyDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAccessPoliciesQuery());
        return Ok(ApiResponse<IEnumerable<AccessPolicyDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AccessPolicyDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAccessPolicyByIdQuery { Id = id });
        return Ok(ApiResponse<AccessPolicyDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAccessPolicyDto dto)
    {
        var id = await sender.Send(new CreateAccessPolicyCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAccessPolicyDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAccessPolicyCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAccessPolicyCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



