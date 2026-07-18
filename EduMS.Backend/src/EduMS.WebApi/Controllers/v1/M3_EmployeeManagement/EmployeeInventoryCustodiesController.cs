using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeInventoryCustodies;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeInventoryCustodies;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeInventoryCustodies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeInventoryCustodiesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeInventoryCustodiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeInventoryCustodyDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllEmployeeInventoryCustodiesQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeInventoryCustodyDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeInventoryCustodyDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetEmployeeInventoryCustodyByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeInventoryCustodyDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeInventoryCustodyDto dto)
    {
        var id = await _mediator.Send(new CreateEmployeeInventoryCustodyCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeInventoryCustodyDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateEmployeeInventoryCustodyCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteEmployeeInventoryCustodyCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}