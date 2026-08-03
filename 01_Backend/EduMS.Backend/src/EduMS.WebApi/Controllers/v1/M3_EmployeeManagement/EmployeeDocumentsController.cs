using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeeDocuments;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeDocuments;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeeDocuments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeeDocumentsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.EmployeeDocuments.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeDocumentDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEmployeeDocumentsQuery());
        return Ok(ApiResponse<IEnumerable<EmployeeDocumentDto>>.Success(result));
    }

    [HasPermission(Permissions.EmployeeDocuments.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeeDocumentDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEmployeeDocumentByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeeDocumentDto>.Success(result));
    }

    [HasPermission(Permissions.EmployeeDocuments.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeeDocumentDto dto)
    {
        var id = await sender.Send(new CreateEmployeeDocumentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.EmployeeDocuments.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeeDocumentDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEmployeeDocumentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.EmployeeDocuments.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEmployeeDocumentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




