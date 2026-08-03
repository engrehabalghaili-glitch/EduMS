using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.PaymentVouchers;
using EduMS.Application.M5_FinancialManagement.DTOs.PaymentVouchers;
using EduMS.Application.M5_FinancialManagement.Queries.PaymentVouchers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class PaymentVouchersController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.PaymentVouchers.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<PaymentVoucherDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllPaymentVouchersQuery());
        return Ok(ApiResponse<IEnumerable<PaymentVoucherDto>>.Success(result));
    }

    [HasPermission(Permissions.PaymentVouchers.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<PaymentVoucherDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetPaymentVoucherByIdQuery { Id = id });
        return Ok(ApiResponse<PaymentVoucherDto>.Success(result));
    }

    [HasPermission(Permissions.PaymentVouchers.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreatePaymentVoucherDto dto)
    {
        var id = await sender.Send(new CreatePaymentVoucherCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.PaymentVouchers.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdatePaymentVoucherDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdatePaymentVoucherCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.PaymentVouchers.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeletePaymentVoucherCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




