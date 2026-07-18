using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.Persons;
using EduMS.Application.M2_StudentAffairs.DTOs.Persons;
using EduMS.Application.M2_StudentAffairs.Queries.Persons;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class PersonsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<PersonDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllPersonsQuery());
        return Ok(ApiResponse<IEnumerable<PersonDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<PersonDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetPersonByIdQuery { Id = id });
        return Ok(ApiResponse<PersonDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreatePersonDto dto)
    {
        var id = await _mediator.Send(new CreatePersonCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdatePersonDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdatePersonCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeletePersonCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}