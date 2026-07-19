using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.StudentAccounts;
using EduMS.Application.M5_FinancialManagement.DTOs.StudentAccounts;
using EduMS.Application.M5_FinancialManagement.Queries.StudentAccounts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentAccountsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentAccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentAccountDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentAccountsQuery());
        return Ok(ApiResponse<IEnumerable<StudentAccountDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentAccountDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentAccountByIdQuery { Id = id });
        return Ok(ApiResponse<StudentAccountDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentAccountDto dto)
    {
        var id = await _mediator.Send(new CreateStudentAccountCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentAccountDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentAccountCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentAccountCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}