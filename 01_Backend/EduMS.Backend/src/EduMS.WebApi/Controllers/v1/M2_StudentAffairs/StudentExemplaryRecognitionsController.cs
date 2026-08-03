using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentExemplaryRecognitions;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentExemplaryRecognitions;
using EduMS.Application.M2_StudentAffairs.Queries.StudentExemplaryRecognitions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentExemplaryRecognitionsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentExemplaryRecognitions.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentExemplaryRecognitionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentExemplaryRecognitionsQuery());
        return Ok(ApiResponse<IEnumerable<StudentExemplaryRecognitionDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentExemplaryRecognitions.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentExemplaryRecognitionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentExemplaryRecognitionByIdQuery { Id = id });
        return Ok(ApiResponse<StudentExemplaryRecognitionDto>.Success(result));
    }

    [HasPermission(Permissions.StudentExemplaryRecognitions.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentExemplaryRecognitionDto dto)
    {
        var id = await sender.Send(new CreateStudentExemplaryRecognitionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentExemplaryRecognitions.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentExemplaryRecognitionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentExemplaryRecognitionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentExemplaryRecognitions.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentExemplaryRecognitionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




