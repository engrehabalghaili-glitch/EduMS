using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentIdentityDocuments;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentIdentityDocuments;
using EduMS.Application.M2_StudentAffairs.Queries.StudentIdentityDocuments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentIdentityDocumentsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentIdentityDocumentDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentIdentityDocumentsQuery());
        return Ok(ApiResponse<IEnumerable<StudentIdentityDocumentDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentIdentityDocumentDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentIdentityDocumentByIdQuery { Id = id });
        return Ok(ApiResponse<StudentIdentityDocumentDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentIdentityDocumentDto dto)
    {
        var id = await sender.Send(new CreateStudentIdentityDocumentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentIdentityDocumentDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentIdentityDocumentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentIdentityDocumentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



