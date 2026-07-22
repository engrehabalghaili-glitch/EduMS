using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeExternalTransfers;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeExternalTransfers;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeExternalTransfers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeExternalTransfersController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeExternalTransfersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeExternalTransferDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllEmployeeExternalTransfersQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeExternalTransferDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeExternalTransferDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetEmployeeExternalTransferByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeExternalTransferDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeExternalTransferDto dto)
    {
        var id = await _mediator.Send(new CreateEmployeeExternalTransferCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeExternalTransferDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateEmployeeExternalTransferCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteEmployeeExternalTransferCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}