using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.FeeInstallments;
using EduMS.Application.M5_FinancialManagement.DTOs.FeeInstallments;
using EduMS.Application.M5_FinancialManagement.Queries.FeeInstallments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class FeeInstallmentsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.FeeInstallments.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<FeeInstallmentDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllFeeInstallmentsQuery());
        return Ok(ApiResponse<IEnumerable<FeeInstallmentDto>>.Success(result));
    }

    [HasPermission(Permissions.FeeInstallments.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<FeeInstallmentDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetFeeInstallmentByIdQuery { Id = id });
        return Ok(ApiResponse<FeeInstallmentDto>.Success(result));
    }

    [HasPermission(Permissions.FeeInstallments.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateFeeInstallmentDto dto)
    {
        var id = await sender.Send(new CreateFeeInstallmentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.FeeInstallments.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateFeeInstallmentDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateFeeInstallmentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.FeeInstallments.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteFeeInstallmentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




