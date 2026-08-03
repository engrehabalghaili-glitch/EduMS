using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.SelfServicePortalRequests;
using EduMS.Application.M3_EmployeeManagement.DTOs.SelfServicePortalRequests;
using EduMS.Application.M3_EmployeeManagement.Queries.SelfServicePortalRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SelfServicePortalRequestsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.SelfServicePortalRequests.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SelfServicePortalRequestDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSelfServicePortalRequestsQuery());
        return Ok(ApiResponse<IEnumerable<SelfServicePortalRequestDto>>.Success(result));
    }

    [HasPermission(Permissions.SelfServicePortalRequests.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SelfServicePortalRequestDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSelfServicePortalRequestByIdQuery { Id = id });
        return Ok(ApiResponse<SelfServicePortalRequestDto>.Success(result));
    }

    [HasPermission(Permissions.SelfServicePortalRequests.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSelfServicePortalRequestDto dto)
    {
        var id = await sender.Send(new CreateSelfServicePortalRequestCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.SelfServicePortalRequests.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSelfServicePortalRequestDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSelfServicePortalRequestCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.SelfServicePortalRequests.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSelfServicePortalRequestCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




