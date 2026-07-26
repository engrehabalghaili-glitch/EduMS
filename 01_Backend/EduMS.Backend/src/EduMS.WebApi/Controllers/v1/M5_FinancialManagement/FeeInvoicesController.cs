using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.FeeInvoices;
using EduMS.Application.M5_FinancialManagement.DTOs.FeeInvoices;
using EduMS.Application.M5_FinancialManagement.Queries.FeeInvoices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class FeeInvoicesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<FeeInvoiceDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllFeeInvoicesQuery());
        return Ok(ApiResponse<IEnumerable<FeeInvoiceDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<FeeInvoiceDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetFeeInvoiceByIdQuery { Id = id });
        return Ok(ApiResponse<FeeInvoiceDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateFeeInvoiceDto dto)
    {
        var id = await sender.Send(new CreateFeeInvoiceCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateFeeInvoiceDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateFeeInvoiceCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteFeeInvoiceCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



