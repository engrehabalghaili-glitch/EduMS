using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentAdmissionApplications;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentAdmissionApplications;
using EduMS.Application.M2_StudentAffairs.Queries.StudentAdmissionApplications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentAdmissionApplicationsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentAdmissionApplications.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentAdmissionApplicationDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentAdmissionApplicationsQuery());
        return Ok(ApiResponse<IEnumerable<StudentAdmissionApplicationDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentAdmissionApplications.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentAdmissionApplicationDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentAdmissionApplicationByIdQuery { Id = id });
        return Ok(ApiResponse<StudentAdmissionApplicationDto>.Success(result));
    }

    [HasPermission(Permissions.StudentAdmissionApplications.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentAdmissionApplicationDto dto)
    {
        var id = await sender.Send(new CreateStudentAdmissionApplicationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentAdmissionApplications.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentAdmissionApplicationDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentAdmissionApplicationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentAdmissionApplications.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentAdmissionApplicationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




