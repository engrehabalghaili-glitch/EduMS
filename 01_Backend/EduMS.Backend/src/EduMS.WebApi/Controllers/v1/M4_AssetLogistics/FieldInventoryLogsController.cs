using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.FieldInventoryLogs;
using EduMS.Application.M4_AssetLogistics.DTOs.FieldInventoryLogs;
using EduMS.Application.M4_AssetLogistics.Queries.FieldInventoryLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class FieldInventoryLogsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.FieldInventoryLogs.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<FieldInventoryLogDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllFieldInventoryLogsQuery());
        return Ok(ApiResponse<IEnumerable<FieldInventoryLogDto>>.Success(result));
    }

    [HasPermission(Permissions.FieldInventoryLogs.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<FieldInventoryLogDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetFieldInventoryLogByIdQuery { Id = id });
        return Ok(ApiResponse<FieldInventoryLogDto>.Success(result));
    }

    [HasPermission(Permissions.FieldInventoryLogs.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateFieldInventoryLogDto dto)
    {
        var id = await sender.Send(new CreateFieldInventoryLogCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.FieldInventoryLogs.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateFieldInventoryLogDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateFieldInventoryLogCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.FieldInventoryLogs.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteFieldInventoryLogCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




