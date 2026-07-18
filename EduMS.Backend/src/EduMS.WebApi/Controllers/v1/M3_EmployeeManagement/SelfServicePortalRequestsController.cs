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
public class SelfServicePortalRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SelfServicePortalRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SelfServicePortalRequestDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSelfServicePortalRequestsQuery());
        return Ok(ApiResponse<IEnumerable<SelfServicePortalRequestDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SelfServicePortalRequestDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSelfServicePortalRequestByIdQuery { Id = id });
        return Ok(ApiResponse<SelfServicePortalRequestDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSelfServicePortalRequestDto dto)
    {
        var id = await _mediator.Send(new CreateSelfServicePortalRequestCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSelfServicePortalRequestDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateSelfServicePortalRequestCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteSelfServicePortalRequestCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}