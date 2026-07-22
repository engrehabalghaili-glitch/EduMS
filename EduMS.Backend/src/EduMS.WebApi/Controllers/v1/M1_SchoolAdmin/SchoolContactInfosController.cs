using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolContactInfos;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolContactInfos;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolContactInfos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolContactInfosController : ControllerBase
{
    private readonly IMediator _mediator;

    public SchoolContactInfosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolContactInfoDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSchoolContactInfosQuery());
        return Ok(ApiResponse<IEnumerable<SchoolContactInfoDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolContactInfoDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSchoolContactInfoByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolContactInfoDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolContactInfoDto dto)
    {
        var id = await _mediator.Send(new CreateSchoolContactInfoCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolContactInfoDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateSchoolContactInfoCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteSchoolContactInfoCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}