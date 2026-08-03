using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeExternalTransfers;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeExternalTransfers;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeExternalTransfers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeExternalTransfersController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.EmployeeExternalTransfers.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeExternalTransferDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEmployeeExternalTransfersQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeExternalTransferDto>>.Success(result));
    }

    [HasPermission(Permissions.EmployeeExternalTransfers.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeExternalTransferDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEmployeeExternalTransferByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeExternalTransferDto>.Success(result));
    }

    [HasPermission(Permissions.EmployeeExternalTransfers.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeExternalTransferDto dto)
    {
        var id = await sender.Send(new CreateEmployeeExternalTransferCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.EmployeeExternalTransfers.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeExternalTransferDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEmployeeExternalTransferCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.EmployeeExternalTransfers.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEmployeeExternalTransferCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




