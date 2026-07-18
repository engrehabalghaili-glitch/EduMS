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
public class StudentFinancialAidApplicationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentFinancialAidApplicationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentFinancialAidApplicationDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentFinancialAidApplicationsQuery());
        return Ok(ApiResponse<IEnumerable<StudentFinancialAidApplicationDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentFinancialAidApplicationDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentFinancialAidApplicationByIdQuery { Id = id });
        return Ok(ApiResponse<StudentFinancialAidApplicationDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentFinancialAidApplicationDto dto)
    {
        var id = await _mediator.Send(new CreateStudentFinancialAidApplicationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentFinancialAidApplicationDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentFinancialAidApplicationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentFinancialAidApplicationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}