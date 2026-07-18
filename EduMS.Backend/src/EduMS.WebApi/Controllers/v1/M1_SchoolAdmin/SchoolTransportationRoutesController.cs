using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolTransportationRoutes;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolTransportationRoutes;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolTransportationRoutes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolTransportationRoutesController : ControllerBase
{
    private readonly IMediator _mediator;

    public SchoolTransportationRoutesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolTransportationRouteDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSchoolTransportationRoutesQuery());
        return Ok(ApiResponse<IEnumerable<SchoolTransportationRouteDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolTransportationRouteDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSchoolTransportationRouteByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolTransportationRouteDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolTransportationRouteDto dto)
    {
        var id = await _mediator.Send(new CreateSchoolTransportationRouteCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolTransportationRouteDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateSchoolTransportationRouteCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteSchoolTransportationRouteCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}