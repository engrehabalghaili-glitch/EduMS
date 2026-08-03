using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.CurriculumTextbookDistributions;
using EduMS.Application.M1_SchoolAdmin.DTOs.CurriculumTextbookDistributions;
using EduMS.Application.M1_SchoolAdmin.Queries.CurriculumTextbookDistributions;
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
public class CurriculumTextbookDistributionsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.CurriculumTextbookDistributions.View)]

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<CurriculumTextbookDistributionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllCurriculumTextbookDistributionsQuery());
        return Ok(ApiResponse<IEnumerable<CurriculumTextbookDistributionDto>>.Success(result));
    }

        [HasPermission(Permissions.CurriculumTextbookDistributions.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<CurriculumTextbookDistributionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetCurriculumTextbookDistributionByIdQuery { Id = id });
        return Ok(ApiResponse<CurriculumTextbookDistributionDto>.Success(result));
    }

    [HasPermission(Permissions.CurriculumTextbookDistributions.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateCurriculumTextbookDistributionDto dto)
    {
        var id = await sender.Send(new CreateCurriculumTextbookDistributionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.CurriculumTextbookDistributions.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateCurriculumTextbookDistributionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateCurriculumTextbookDistributionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.CurriculumTextbookDistributions.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteCurriculumTextbookDistributionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}







