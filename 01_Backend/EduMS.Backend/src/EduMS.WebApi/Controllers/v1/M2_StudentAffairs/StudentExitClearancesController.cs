using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentExitClearances;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentExitClearances;
using EduMS.Application.M2_StudentAffairs.Queries.StudentExitClearances;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentExitClearancesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentExitClearanceDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentExitClearancesQuery());
        return Ok(ApiResponse<IEnumerable<StudentExitClearanceDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentExitClearanceDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentExitClearanceByIdQuery { Id = id });
        return Ok(ApiResponse<StudentExitClearanceDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentExitClearanceDto dto)
    {
        var id = await sender.Send(new CreateStudentExitClearanceCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentExitClearanceDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentExitClearanceCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentExitClearanceCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



