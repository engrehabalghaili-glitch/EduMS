using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.PayrollDetails;
using EduMS.Application.M5_FinancialManagement.DTOs.PayrollDetails;
using EduMS.Application.M5_FinancialManagement.Queries.PayrollDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class PayrollDetailsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<PayrollDetailDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllPayrollDetailsQuery());
        return Ok(ApiResponse<IEnumerable<PayrollDetailDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<PayrollDetailDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetPayrollDetailByIdQuery { Id = id });
        return Ok(ApiResponse<PayrollDetailDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreatePayrollDetailDto dto)
    {
        var id = await sender.Send(new CreatePayrollDetailCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdatePayrollDetailDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdatePayrollDetailCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeletePayrollDetailCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



