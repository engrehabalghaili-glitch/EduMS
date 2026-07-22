using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolCanteenItems;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCanteenItems;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolCanteenItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolCanteenItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SchoolCanteenItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolCanteenItemDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSchoolCanteenItemsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolCanteenItemDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolCanteenItemDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSchoolCanteenItemByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolCanteenItemDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolCanteenItemDto dto)
    {
        var id = await _mediator.Send(new CreateSchoolCanteenItemCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolCanteenItemDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateSchoolCanteenItemCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteSchoolCanteenItemCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}