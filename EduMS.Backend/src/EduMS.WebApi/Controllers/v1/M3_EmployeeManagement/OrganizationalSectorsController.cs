using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.OrganizationalSectors;
using EduMS.Application.M3_EmployeeManagement.DTOs.OrganizationalSectors;
using EduMS.Application.M3_EmployeeManagement.Queries.OrganizationalSectors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class OrganizationalSectorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrganizationalSectorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<OrganizationalSectorDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllOrganizationalSectorsQuery());
        return Ok(ApiResponse<IEnumerable<OrganizationalSectorDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<OrganizationalSectorDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetOrganizationalSectorByIdQuery { Id = id });
        return Ok(ApiResponse<OrganizationalSectorDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateOrganizationalSectorDto dto)
    {
        var id = await _mediator.Send(new CreateOrganizationalSectorCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateOrganizationalSectorDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateOrganizationalSectorCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteOrganizationalSectorCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}