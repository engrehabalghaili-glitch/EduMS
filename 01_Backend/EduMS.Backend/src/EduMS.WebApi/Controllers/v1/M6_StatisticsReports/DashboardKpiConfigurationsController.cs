using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M6_StatisticsReports.Commands.DashboardKpiConfigurations;
using EduMS.Application.M6_StatisticsReports.DTOs.DashboardKpiConfigurations;
using EduMS.Application.M6_StatisticsReports.Queries.DashboardKpiConfigurations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M6_StatisticsReports;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class DashboardKpiConfigurationsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.DashboardKpiConfigurations.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<DashboardKpiConfigurationDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllDashboardKpiConfigurationsQuery());
        return Ok(ApiResponse<IEnumerable<DashboardKpiConfigurationDto>>.Success(result));
    }

    [HasPermission(Permissions.DashboardKpiConfigurations.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<DashboardKpiConfigurationDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetDashboardKpiConfigurationByIdQuery { Id = id });
        return Ok(ApiResponse<DashboardKpiConfigurationDto>.Success(result));
    }

    [HasPermission(Permissions.DashboardKpiConfigurations.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateDashboardKpiConfigurationDto dto)
    {
        var id = await sender.Send(new CreateDashboardKpiConfigurationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.DashboardKpiConfigurations.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateDashboardKpiConfigurationDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateDashboardKpiConfigurationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.DashboardKpiConfigurations.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteDashboardKpiConfigurationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




