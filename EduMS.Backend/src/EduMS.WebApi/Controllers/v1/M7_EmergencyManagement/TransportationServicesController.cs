using EduMS.Application.Common.Responses;
using EduMS.Application.M7_EmergencyManagement.Commands.TransportationServices;
using EduMS.Application.M7_EmergencyManagement.DTOs.TransportationServices;
using EduMS.Application.M7_EmergencyManagement.Queries.TransportationServices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M7_EmergencyManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class TransportationServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransportationServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<TransportationServiceDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllTransportationServicesQuery());
        return Ok(ApiResponse<IEnumerable<TransportationServiceDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<TransportationServiceDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetTransportationServiceByIdQuery { Id = id });
        return Ok(ApiResponse<TransportationServiceDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateTransportationServiceDto dto)
    {
        var id = await _mediator.Send(new CreateTransportationServiceCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateTransportationServiceDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateTransportationServiceCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteTransportationServiceCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}