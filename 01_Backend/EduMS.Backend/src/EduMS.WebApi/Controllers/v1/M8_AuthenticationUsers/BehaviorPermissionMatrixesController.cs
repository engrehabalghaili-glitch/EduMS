using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.BehaviorPermissionMatrixes;
using EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissionMatrixes;
using EduMS.Application.M8_AuthenticationUsers.Queries.BehaviorPermissionMatrixes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class BehaviorPermissionMatrixesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<BehaviorPermissionMatrixDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllBehaviorPermissionMatrixesQuery());
        return Ok(ApiResponse<IEnumerable<BehaviorPermissionMatrixDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<BehaviorPermissionMatrixDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetBehaviorPermissionMatrixByIdQuery { Id = id });
        return Ok(ApiResponse<BehaviorPermissionMatrixDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateBehaviorPermissionMatrixDto dto)
    {
        var id = await sender.Send(new CreateBehaviorPermissionMatrixCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateBehaviorPermissionMatrixDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateBehaviorPermissionMatrixCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteBehaviorPermissionMatrixCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



