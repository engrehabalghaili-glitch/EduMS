using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
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
public class OrganizationalSectorsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.OrganizationalSectors.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<OrganizationalSectorDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllOrganizationalSectorsQuery());
        return Ok(ApiResponse<IEnumerable<OrganizationalSectorDto>>.Success(result));
    }

    [HasPermission(Permissions.OrganizationalSectors.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<OrganizationalSectorDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetOrganizationalSectorByIdQuery { Id = id });
        return Ok(ApiResponse<OrganizationalSectorDto>.Success(result));
    }

    [HasPermission(Permissions.OrganizationalSectors.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateOrganizationalSectorDto dto)
    {
        var id = await sender.Send(new CreateOrganizationalSectorCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.OrganizationalSectors.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateOrganizationalSectorDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateOrganizationalSectorCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.OrganizationalSectors.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteOrganizationalSectorCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




