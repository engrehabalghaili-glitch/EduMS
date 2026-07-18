using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.StaffCustodySummaries;
using EduMS.Application.M3_EmployeeManagement.DTOs.StaffCustodySummaries;
using EduMS.Application.M3_EmployeeManagement.Queries.StaffCustodySummaries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StaffCustodySummariesController : ControllerBase
{
    private readonly IMediator _mediator;

    public StaffCustodySummariesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StaffCustodySummaryDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStaffCustodySummariesQuery());
        return Ok(ApiResponse<IEnumerable<StaffCustodySummaryDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StaffCustodySummaryDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStaffCustodySummaryByIdQuery { Id = id });
        return Ok(ApiResponse<StaffCustodySummaryDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStaffCustodySummaryDto dto)
    {
        var id = await _mediator.Send(new CreateStaffCustodySummaryCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStaffCustodySummaryDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStaffCustodySummaryCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStaffCustodySummaryCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}