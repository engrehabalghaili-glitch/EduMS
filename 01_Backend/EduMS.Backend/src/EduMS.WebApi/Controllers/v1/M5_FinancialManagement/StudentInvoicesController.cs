using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.StudentInvoices;
using EduMS.Application.M5_FinancialManagement.DTOs.StudentInvoices;
using EduMS.Application.M5_FinancialManagement.Queries.StudentInvoices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentInvoicesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.StudentInvoices.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentInvoiceDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentInvoicesQuery());
        return Ok(ApiResponse<IEnumerable<StudentInvoiceDto>>.Success(result));
    }

    [HasPermission(Permissions.StudentInvoices.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentInvoiceDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentInvoiceByIdQuery { Id = id });
        return Ok(ApiResponse<StudentInvoiceDto>.Success(result));
    }

    [HasPermission(Permissions.StudentInvoices.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentInvoiceDto dto)
    {
        var id = await sender.Send(new CreateStudentInvoiceCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.StudentInvoices.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentInvoiceDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentInvoiceCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.StudentInvoices.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentInvoiceCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




