using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.ClassroomResourceAllocations;
using EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomResourceAllocations;
using EduMS.Application.M1_SchoolAdmin.Queries.ClassroomResourceAllocations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ClassroomResourceAllocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClassroomResourceAllocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ClassroomResourceAllocationDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllClassroomResourceAllocationsQuery());
        return Ok(ApiResponse<IEnumerable<ClassroomResourceAllocationDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ClassroomResourceAllocationDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetClassroomResourceAllocationByIdQuery { Id = id });
        return Ok(ApiResponse<ClassroomResourceAllocationDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateClassroomResourceAllocationDto dto)
    {
        var id = await _mediator.Send(new CreateClassroomResourceAllocationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateClassroomResourceAllocationDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateClassroomResourceAllocationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteClassroomResourceAllocationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}