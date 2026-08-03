using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolTransportationRoutes;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolTransportationRoutes;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolTransportationRoutes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolTransportationRoutesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.SchoolTransportationRoutes.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolTransportationRouteDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSchoolTransportationRoutesQuery());
        return Ok(ApiResponse<IEnumerable<SchoolTransportationRouteDto>>.Success(result));
    }

        [HasPermission(Permissions.SchoolTransportationRoutes.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolTransportationRouteDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSchoolTransportationRouteByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolTransportationRouteDto>.Success(result));
    }

    [HasPermission(Permissions.SchoolTransportationRoutes.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolTransportationRouteDto dto)
    {
        var id = await sender.Send(new CreateSchoolTransportationRouteCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.SchoolTransportationRoutes.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolTransportationRouteDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSchoolTransportationRouteCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.SchoolTransportationRoutes.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSchoolTransportationRouteCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







