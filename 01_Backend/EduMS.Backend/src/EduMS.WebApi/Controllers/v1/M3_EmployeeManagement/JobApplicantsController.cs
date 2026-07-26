using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.JobApplicants;
using EduMS.Application.M3_EmployeeManagement.DTOs.JobApplicants;
using EduMS.Application.M3_EmployeeManagement.Queries.JobApplicants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class JobApplicantsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<JobApplicantDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllJobApplicantsQuery());
        return Ok(ApiResponse<IEnumerable<JobApplicantDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<JobApplicantDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetJobApplicantByIdQuery { Id = id });
        return Ok(ApiResponse<JobApplicantDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateJobApplicantDto dto)
    {
        var id = await sender.Send(new CreateJobApplicantCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateJobApplicantDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateJobApplicantCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteJobApplicantCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



