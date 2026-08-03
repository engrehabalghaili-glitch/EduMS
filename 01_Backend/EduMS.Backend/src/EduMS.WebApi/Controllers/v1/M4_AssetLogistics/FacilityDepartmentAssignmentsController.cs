using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.FacilityDepartmentAssignments;
using EduMS.Application.M4_AssetLogistics.DTOs.FacilityDepartmentAssignments;
using EduMS.Application.M4_AssetLogistics.Queries.FacilityDepartmentAssignments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class FacilityDepartmentAssignmentsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.FacilityDepartmentAssignments.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<FacilityDepartmentAssignmentDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllFacilityDepartmentAssignmentsQuery());
        return Ok(ApiResponse<IEnumerable<FacilityDepartmentAssignmentDto>>.Success(result));
    }

    [HasPermission(Permissions.FacilityDepartmentAssignments.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<FacilityDepartmentAssignmentDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetFacilityDepartmentAssignmentByIdQuery { Id = id });
        return Ok(ApiResponse<FacilityDepartmentAssignmentDto>.Success(result));
    }

    [HasPermission(Permissions.FacilityDepartmentAssignments.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateFacilityDepartmentAssignmentDto dto)
    {
        var id = await sender.Send(new CreateFacilityDepartmentAssignmentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.FacilityDepartmentAssignments.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateFacilityDepartmentAssignmentDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateFacilityDepartmentAssignmentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.FacilityDepartmentAssignments.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteFacilityDepartmentAssignmentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




