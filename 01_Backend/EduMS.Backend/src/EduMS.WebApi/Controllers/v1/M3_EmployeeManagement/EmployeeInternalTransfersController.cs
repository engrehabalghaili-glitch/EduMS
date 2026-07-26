using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeInternalTransfers;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeInternalTransfers;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeInternalTransfers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeInternalTransfersController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeInternalTransferDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEmployeeInternalTransfersQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeInternalTransferDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeInternalTransferDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEmployeeInternalTransferByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeInternalTransferDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeInternalTransferDto dto)
    {
        var id = await sender.Send(new CreateEmployeeInternalTransferCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeInternalTransferDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEmployeeInternalTransferCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEmployeeInternalTransferCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



