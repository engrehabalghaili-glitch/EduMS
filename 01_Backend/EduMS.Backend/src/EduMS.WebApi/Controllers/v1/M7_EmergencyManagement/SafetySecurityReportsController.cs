using EduMS.Application.Common.Responses;
using EduMS.Application.M7_EmergencyManagement.Commands.SafetySecurityReports;
using EduMS.Application.M7_EmergencyManagement.DTOs.SafetySecurityReports;
using EduMS.Application.M7_EmergencyManagement.Queries.SafetySecurityReports;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M7_EmergencyManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SafetySecurityReportsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SafetySecurityReportDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSafetySecurityReportsQuery());
        return Ok(ApiResponse<IEnumerable<SafetySecurityReportDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SafetySecurityReportDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSafetySecurityReportByIdQuery { Id = id });
        return Ok(ApiResponse<SafetySecurityReportDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSafetySecurityReportDto dto)
    {
        var id = await sender.Send(new CreateSafetySecurityReportCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSafetySecurityReportDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSafetySecurityReportCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSafetySecurityReportCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



