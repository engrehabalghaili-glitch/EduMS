using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentAttachments;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentAttachments;
using EduMS.Application.M2_StudentAffairs.Queries.StudentAttachments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentAttachmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentAttachmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentAttachmentDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllStudentAttachmentsQuery());
        return Ok(ApiResponse<IEnumerable<StudentAttachmentDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentAttachmentDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetStudentAttachmentByIdQuery { Id = id });
        return Ok(ApiResponse<StudentAttachmentDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentAttachmentDto dto)
    {
        var id = await _mediator.Send(new CreateStudentAttachmentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentAttachmentDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateStudentAttachmentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteStudentAttachmentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}