using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.VacantPositions;
using EduMS.Application.M3_EmployeeManagement.DTOs.VacantPositions;
using EduMS.Application.M3_EmployeeManagement.Queries.VacantPositions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class VacantPositionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public VacantPositionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<VacantPositionDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllVacantPositionsQuery());
        return Ok(ApiResponse<IEnumerable<VacantPositionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<VacantPositionDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetVacantPositionByIdQuery { Id = id });
        return Ok(ApiResponse<VacantPositionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateVacantPositionDto dto)
    {
        var id = await _mediator.Send(new CreateVacantPositionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateVacantPositionDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateVacantPositionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteVacantPositionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}