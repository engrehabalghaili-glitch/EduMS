using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.Vendors;
using EduMS.Application.M5_FinancialManagement.DTOs.Vendors;
using EduMS.Application.M5_FinancialManagement.Queries.Vendors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class VendorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public VendorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<VendorDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllVendorsQuery());
        return Ok(ApiResponse<IEnumerable<VendorDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<VendorDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetVendorByIdQuery { Id = id });
        return Ok(ApiResponse<VendorDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateVendorDto dto)
    {
        var id = await _mediator.Send(new CreateVendorCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateVendorDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateVendorCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteVendorCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}