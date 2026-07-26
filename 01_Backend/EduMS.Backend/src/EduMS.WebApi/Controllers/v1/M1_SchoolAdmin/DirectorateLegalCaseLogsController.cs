using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.DirectorateLegalCaseLogs;
using EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateLegalCaseLogs;
using EduMS.Application.M1_SchoolAdmin.Queries.DirectorateLegalCaseLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class DirectorateLegalCaseLogsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<DirectorateLegalCaseLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllDirectorateLegalCaseLogsQuery());
        return Ok(ApiResponse<IEnumerable<DirectorateLegalCaseLogDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<DirectorateLegalCaseLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetDirectorateLegalCaseLogByIdQuery { Id = id });
        return Ok(ApiResponse<DirectorateLegalCaseLogDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateDirectorateLegalCaseLogDto dto)
    {
        var id = await sender.Send(new CreateDirectorateLegalCaseLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateDirectorateLegalCaseLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateDirectorateLegalCaseLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteDirectorateLegalCaseLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



