using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.FeeTypes;
using EduMS.Application.M5_FinancialManagement.DTOs.FeeTypes;
using EduMS.Application.M5_FinancialManagement.Queries.FeeTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class FeeTypesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<FeeTypeDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllFeeTypesQuery());
        return Ok(ApiResponse<IEnumerable<FeeTypeDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<FeeTypeDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetFeeTypeByIdQuery { Id = id });
        return Ok(ApiResponse<FeeTypeDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateFeeTypeDto dto)
    {
        var id = await sender.Send(new CreateFeeTypeCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateFeeTypeDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateFeeTypeCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteFeeTypeCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



