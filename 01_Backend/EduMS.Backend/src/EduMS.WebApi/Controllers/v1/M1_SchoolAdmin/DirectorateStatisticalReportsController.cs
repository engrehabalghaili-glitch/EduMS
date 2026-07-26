using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.DirectorateStatisticalReports;
using EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateStatisticalReports;
using EduMS.Application.M1_SchoolAdmin.Queries.DirectorateStatisticalReports;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class DirectorateStatisticalReportsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<DirectorateStatisticalReportDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllDirectorateStatisticalReportsQuery());
        return Ok(ApiResponse<IEnumerable<DirectorateStatisticalReportDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<DirectorateStatisticalReportDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetDirectorateStatisticalReportByIdQuery { Id = id });
        return Ok(ApiResponse<DirectorateStatisticalReportDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateDirectorateStatisticalReportDto dto)
    {
        var id = await sender.Send(new CreateDirectorateStatisticalReportCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateDirectorateStatisticalReportDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateDirectorateStatisticalReportCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteDirectorateStatisticalReportCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



