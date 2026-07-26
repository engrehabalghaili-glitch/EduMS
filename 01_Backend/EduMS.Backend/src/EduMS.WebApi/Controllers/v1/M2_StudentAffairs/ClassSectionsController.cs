using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.ClassSections;
using EduMS.Application.M2_StudentAffairs.DTOs.ClassSections;
using EduMS.Application.M2_StudentAffairs.Queries.ClassSections;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ClassSectionsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ClassSectionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllClassSectionsQuery());
        return Ok(ApiResponse<IEnumerable<ClassSectionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ClassSectionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetClassSectionByIdQuery { Id = id });
        return Ok(ApiResponse<ClassSectionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateClassSectionDto dto)
    {
        var id = await sender.Send(new CreateClassSectionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateClassSectionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateClassSectionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteClassSectionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



