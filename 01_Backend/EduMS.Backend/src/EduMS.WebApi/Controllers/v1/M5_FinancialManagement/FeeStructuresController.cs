using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.FeeStructures;
using EduMS.Application.M5_FinancialManagement.DTOs.FeeStructures;
using EduMS.Application.M5_FinancialManagement.Queries.FeeStructures;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class FeeStructuresController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.FeeStructures.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<FeeStructureDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllFeeStructuresQuery());
        return Ok(ApiResponse<IEnumerable<FeeStructureDto>>.Success(result));
    }

    [HasPermission(Permissions.FeeStructures.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<FeeStructureDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetFeeStructureByIdQuery { Id = id });
        return Ok(ApiResponse<FeeStructureDto>.Success(result));
    }

    [HasPermission(Permissions.FeeStructures.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateFeeStructureDto dto)
    {
        var id = await sender.Send(new CreateFeeStructureCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.FeeStructures.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateFeeStructureDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateFeeStructureCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.FeeStructures.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteFeeStructureCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




