using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.MaintenanceSpareParts;
using EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceSpareParts;
using EduMS.Application.M4_AssetLogistics.Queries.MaintenanceSpareParts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class MaintenanceSparePartsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MaintenanceSparePartsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<MaintenanceSparePartDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllMaintenanceSparePartsQuery());
        return Ok(ApiResponse<IEnumerable<MaintenanceSparePartDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<MaintenanceSparePartDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetMaintenanceSparePartByIdQuery { Id = id });
        return Ok(ApiResponse<MaintenanceSparePartDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateMaintenanceSparePartDto dto)
    {
        var id = await _mediator.Send(new CreateMaintenanceSparePartCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateMaintenanceSparePartDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateMaintenanceSparePartCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteMaintenanceSparePartCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}