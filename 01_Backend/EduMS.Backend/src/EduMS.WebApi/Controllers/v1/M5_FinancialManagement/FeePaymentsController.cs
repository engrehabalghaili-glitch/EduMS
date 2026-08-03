using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.FeePayments;
using EduMS.Application.M5_FinancialManagement.DTOs.FeePayments;
using EduMS.Application.M5_FinancialManagement.Queries.FeePayments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class FeePaymentsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.FeePayments.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<FeePaymentDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllFeePaymentsQuery());
        return Ok(ApiResponse<IEnumerable<FeePaymentDto>>.Success(result));
    }

    [HasPermission(Permissions.FeePayments.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<FeePaymentDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetFeePaymentByIdQuery { Id = id });
        return Ok(ApiResponse<FeePaymentDto>.Success(result));
    }

    [HasPermission(Permissions.FeePayments.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateFeePaymentDto dto)
    {
        var id = await sender.Send(new CreateFeePaymentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.FeePayments.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateFeePaymentDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateFeePaymentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.FeePayments.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteFeePaymentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




