using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentFinancialAidApplications;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentFinancialAidApplications;
using EduMS.Application.M2_StudentAffairs.Queries.StudentFinancialAidApplications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentFinancialAidApplicationsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentFinancialAidApplications.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentFinancialAidApplicationDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentFinancialAidApplicationsQuery());
        return Ok(ApiResponse<IEnumerable<StudentFinancialAidApplicationDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentFinancialAidApplications.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentFinancialAidApplicationDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentFinancialAidApplicationByIdQuery { Id = id });
        return Ok(ApiResponse<StudentFinancialAidApplicationDto>.Success(result));
    }

    [HasPermission(Permissions.StudentFinancialAidApplications.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentFinancialAidApplicationDto dto)
    {
        var id = await sender.Send(new CreateStudentFinancialAidApplicationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentFinancialAidApplications.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentFinancialAidApplicationDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentFinancialAidApplicationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentFinancialAidApplications.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentFinancialAidApplicationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




