using EduMS.Application.Common.Responses;
using EduMS.Application.M2_StudentAffairs.Commands.StudentTransportationSubscriptions;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentTransportationSubscriptions;
using EduMS.Application.M2_StudentAffairs.Queries.StudentTransportationSubscriptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M2_StudentAffairs;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class StudentTransportationSubscriptionsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<StudentTransportationSubscriptionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllStudentTransportationSubscriptionsQuery());
        return Ok(ApiResponse<IEnumerable<StudentTransportationSubscriptionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<StudentTransportationSubscriptionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetStudentTransportationSubscriptionByIdQuery { Id = id });
        return Ok(ApiResponse<StudentTransportationSubscriptionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateStudentTransportationSubscriptionDto dto)
    {
        var id = await sender.Send(new CreateStudentTransportationSubscriptionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateStudentTransportationSubscriptionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateStudentTransportationSubscriptionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteStudentTransportationSubscriptionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



