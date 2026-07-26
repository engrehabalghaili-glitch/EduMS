using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentInventoryCustodies;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentInventoryCustodies;
using EduMS.Application.M2_StudentAffairs.Queries.StudentInventoryCustodies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentInventoryCustodiesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentInventoryCustodyDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentInventoryCustodiesQuery());
        return Ok(ApiResponse<IEnumerable<StudentInventoryCustodyDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentInventoryCustodyDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentInventoryCustodyByIdQuery { Id = id });
        return Ok(ApiResponse<StudentInventoryCustodyDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentInventoryCustodyDto dto)
    {
        var id = await sender.Send(new CreateStudentInventoryCustodyCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentInventoryCustodyDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentInventoryCustodyCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentInventoryCustodyCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



