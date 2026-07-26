using EduMS.Application.Common.Responses;
using EduMS.Application.M3_EmployeeManagement.Commands.EmployeePerformanceReviews;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePerformanceReviews;
using EduMS.Application.M3_EmployeeManagement.Queries.EmployeePerformanceReviews;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M3_EmployeeManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EmployeePerformanceReviewsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EmployeePerformanceReviewDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllEmployeePerformanceReviewsQuery());
        return Ok(ApiResponse<IEnumerable<EmployeePerformanceReviewDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<EmployeePerformanceReviewDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetEmployeePerformanceReviewByIdQuery { Id = id });
        return Ok(ApiResponse<EmployeePerformanceReviewDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateEmployeePerformanceReviewDto dto)
    {
        var id = await sender.Send(new CreateEmployeePerformanceReviewCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateEmployeePerformanceReviewDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateEmployeePerformanceReviewCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteEmployeePerformanceReviewCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



