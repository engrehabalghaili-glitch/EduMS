using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.SchoolAssets;
using EduMS.Application.M4_AssetLogistics.DTOs.SchoolAssets;
using EduMS.Application.M4_AssetLogistics.Queries.SchoolAssets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SchoolAssetsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SchoolAssetsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SchoolAssetDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSchoolAssetsQuery());
        return Ok(ApiResponse<IEnumerable<SchoolAssetDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SchoolAssetDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSchoolAssetByIdQuery { Id = id });
        return Ok(ApiResponse<SchoolAssetDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSchoolAssetDto dto)
    {
        var id = await _mediator.Send(new CreateSchoolAssetCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSchoolAssetDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateSchoolAssetCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteSchoolAssetCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}