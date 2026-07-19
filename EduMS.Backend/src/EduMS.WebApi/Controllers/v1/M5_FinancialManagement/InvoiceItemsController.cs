using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.InvoiceItems;
using EduMS.Application.M5_FinancialManagement.DTOs.InvoiceItems;
using EduMS.Application.M5_FinancialManagement.Queries.InvoiceItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class InvoiceItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public InvoiceItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<InvoiceItemDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllInvoiceItemsQuery());
        return Ok(ApiResponse<IEnumerable<InvoiceItemDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<InvoiceItemDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetInvoiceItemByIdQuery { Id = id });
        return Ok(ApiResponse<InvoiceItemDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateInvoiceItemDto dto)
    {
        var id = await _mediator.Send(new CreateInvoiceItemCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateInvoiceItemDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateInvoiceItemCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteInvoiceItemCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}