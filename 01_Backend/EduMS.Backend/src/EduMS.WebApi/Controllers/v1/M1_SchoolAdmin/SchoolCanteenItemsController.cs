using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.SchoolCanteenItems;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCanteenItems;
using EduMS.Application.M1_SchoolAdmin.Queries.SchoolCanteenItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolCanteenItemsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.SchoolCanteenItems.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolCanteenItemDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSchoolCanteenItemsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolCanteenItemDto>>.Success(result));
    }

        [HasPermission(Permissions.SchoolCanteenItems.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolCanteenItemDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSchoolCanteenItemByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolCanteenItemDto>.Success(result));
    }

    [HasPermission(Permissions.SchoolCanteenItems.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolCanteenItemDto dto)
    {
        var id = await sender.Send(new CreateSchoolCanteenItemCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.SchoolCanteenItems.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolCanteenItemDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSchoolCanteenItemCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.SchoolCanteenItems.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSchoolCanteenItemCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







