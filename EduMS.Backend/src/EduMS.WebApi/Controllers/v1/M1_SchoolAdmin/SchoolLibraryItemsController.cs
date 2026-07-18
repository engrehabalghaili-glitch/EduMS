using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolLibraryItems;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolLibraryItems;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolLibraryItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolLibraryItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SchoolLibraryItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolLibraryItemDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSchoolLibraryItemsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolLibraryItemDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolLibraryItemDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSchoolLibraryItemByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolLibraryItemDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolLibraryItemDto dto)
    {
        var id = await _mediator.Send(new CreateSchoolLibraryItemCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolLibraryItemDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateSchoolLibraryItemCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteSchoolLibraryItemCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}