using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
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
public class StaffCustodySummariesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StaffCustodySummaries.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StaffCustodySummaryDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStaffCustodySummariesQuery());
        return Ok(ApiResponse<IEnumerable<StaffCustodySummaryDto>>.Success(result));
    }

    [HasPermission(Permissions.StaffCustodySummaries.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StaffCustodySummaryDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStaffCustodySummaryByIdQuery { Id = id });
        return Ok(ApiResponse<StaffCustodySummaryDto>.Success(result));
    }

    [HasPermission(Permissions.StaffCustodySummaries.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStaffCustodySummaryDto dto)
    {
        var id = await sender.Send(new CreateStaffCustodySummaryCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StaffCustodySummaries.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStaffCustodySummaryDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStaffCustodySummaryCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StaffCustodySummaries.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStaffCustodySummaryCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




