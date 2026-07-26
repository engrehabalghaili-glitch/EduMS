using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentSkillAndTalentRecords;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentSkillAndTalentRecords;
using EduMS.Application.M2_StudentAffairs.Queries.StudentSkillAndTalentRecords;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentSkillAndTalentRecordsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentSkillAndTalentRecordDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentSkillAndTalentRecordsQuery());
        return Ok(ApiResponse<IEnumerable<StudentSkillAndTalentRecordDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentSkillAndTalentRecordDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentSkillAndTalentRecordByIdQuery { Id = id });
        return Ok(ApiResponse<StudentSkillAndTalentRecordDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentSkillAndTalentRecordDto dto)
    {
        var id = await sender.Send(new CreateStudentSkillAndTalentRecordCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentSkillAndTalentRecordDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentSkillAndTalentRecordCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentSkillAndTalentRecordCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



