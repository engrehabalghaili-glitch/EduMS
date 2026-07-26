using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.PayrollRuns;
using EduMS.Application.M5_FinancialManagement.DTOs.PayrollRuns;
using EduMS.Application.M5_FinancialManagement.Queries.PayrollRuns;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class PayrollRunsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<PayrollRunDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllPayrollRunsQuery());
        return Ok(ApiResponse<IEnumerable<PayrollRunDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<PayrollRunDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetPayrollRunByIdQuery { Id = id });
        return Ok(ApiResponse<PayrollRunDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreatePayrollRunDto dto)
    {
        var id = await sender.Send(new CreatePayrollRunCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdatePayrollRunDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdatePayrollRunCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeletePayrollRunCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



