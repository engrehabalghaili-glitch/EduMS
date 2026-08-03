using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.DirectorateExamCenterAssignments;
using EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateExamCenterAssignments;
using EduMS.Application.M1_SchoolAdmin.Queries.DirectorateExamCenterAssignments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class DirectorateExamCenterAssignmentsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.DirectorateExamCenterAssignments.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<DirectorateExamCenterAssignmentDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllDirectorateExamCenterAssignmentsQuery());
        return Ok(ApiResponse<IEnumerable<DirectorateExamCenterAssignmentDto>>.Success(result));
    }

        [HasPermission(Permissions.DirectorateExamCenterAssignments.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<DirectorateExamCenterAssignmentDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetDirectorateExamCenterAssignmentByIdQuery { Id = id });
        return Ok(ApiResponse<DirectorateExamCenterAssignmentDto>.Success(result));
    }

    [HasPermission(Permissions.DirectorateExamCenterAssignments.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateDirectorateExamCenterAssignmentDto dto)
    {
        var id = await sender.Send(new CreateDirectorateExamCenterAssignmentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.DirectorateExamCenterAssignments.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateDirectorateExamCenterAssignmentDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateDirectorateExamCenterAssignmentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.DirectorateExamCenterAssignments.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteDirectorateExamCenterAssignmentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







