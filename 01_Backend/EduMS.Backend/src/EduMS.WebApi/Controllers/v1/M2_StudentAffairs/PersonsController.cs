using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
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
public class PersonsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.Persons.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<PersonDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllPersonsQuery());
        return Ok(ApiResponse<IEnumerable<PersonDto>>.Success(result));
    }

    [HasPermission(Permissions.Persons.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<PersonDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetPersonByIdQuery { Id = id });
        return Ok(ApiResponse<PersonDto>.Success(result));
    }

    [HasPermission(Permissions.Persons.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreatePersonDto dto)
    {
        var id = await sender.Send(new CreatePersonCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.Persons.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdatePersonDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdatePersonCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.Persons.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeletePersonCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




