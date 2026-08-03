using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.TrainingCourseOfferings;
using EduMS.Application.M1_SchoolAdmin.DTOs.TrainingCourseOfferings;
using EduMS.Application.M1_SchoolAdmin.Queries.TrainingCourseOfferings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class TrainingCourseOfferingsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.TrainingCourseOfferings.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<TrainingCourseOfferingDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllTrainingCourseOfferingsQuery());
        return Ok(ApiResponse<IEnumerable<TrainingCourseOfferingDto>>.Success(result));
    }

        [HasPermission(Permissions.TrainingCourseOfferings.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<TrainingCourseOfferingDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetTrainingCourseOfferingByIdQuery { Id = id });
        return Ok(ApiResponse<TrainingCourseOfferingDto>.Success(result));
    }

    [HasPermission(Permissions.TrainingCourseOfferings.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateTrainingCourseOfferingDto dto)
    {
        var id = await sender.Send(new CreateTrainingCourseOfferingCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.TrainingCourseOfferings.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateTrainingCourseOfferingDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateTrainingCourseOfferingCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.TrainingCourseOfferings.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteTrainingCourseOfferingCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







